using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace NorthSussexJudo
{
    public partial class MainMenu : Form
    {
        private int page = 0;
        private Mode mode = Mode.NONE;
        private List<Guid> athletes = new List<Guid>();
        private Dictionary<Guid, Button> buttons = new Dictionary<Guid, Button>();

        public MainMenu()
        {
            InitializeComponent();
            JsonManager.Load(); //Load data from JSON files into storage before the form is displayed
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            foreach (var i in AthleteStorage.GetAll()) //Retrieve all athletes from storage and add them to the form
            {
                AddAthlete(i);
            }            
            EnableButtons(); //Initially set button states based on whether or not there are any athletes in storage

            //Test Code - Add 30 athletes to test pagination
            //for (int i = 0; i < 30; i++)
            //{
            //    Athlete tester = new Athlete(
            //        Guid.NewGuid(),
            //        "Test Athlete " + (i + 1),
            //        TrainingPlans.GetPlan("Beginner"),
            //        66f,
            //        WeightCategories.GetCategory("Fly"),
            //        0,
            //        0
            //    );

            //    AthleteStorage.Register(tester);

            //    AddAthlete(tester);
            //}
        }

        private void Register_Click(object sender, EventArgs e)
        {
            var form = new RegistrationForm();

            //Subscribe to the onRegistered event of the registration form to add the newly registered athlete
            //to the main menu when the form is submitted      
            form.onRegistered += (s, athlete) => AddAthlete(athlete); 
            form.ShowDialog();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            EnterMode(!IsEditing() ? Mode.EDIT : Mode.NONE);
        }
        private void Remove_Click(object sender, EventArgs e)
        {
            EnterMode(!IsDeleting() ? Mode.REMOVE : Mode.NONE);
        }

        private void AthleteButton_Click(object sender, EventArgs e)
        {
            if (sender is Button btn && btn.Tag is Guid id)
            {
                if (IsDeleting())
                {
                    var result = MessageBox.Show(
                        $"Are you sure you want to delete {AthleteStorage.Get(id).Name}?",
                        "Confirm Deletion",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.Yes)                    
                        RemoveAthlete(id);                    
                } 
                else if (IsEditing())
                {
                    var form = new EditForm(AthleteStorage.Get(id));
                    //Subscribe to the onEdited event of the edit form to update the athlete's button text
                    //on the main menu when the form is submitted
                    form.onEdited += (s, athlete) => EditAthlete(athlete);
                    form.ShowDialog();
                }
                else
                {
                    var athlete = AthleteStorage.Get(id);
                    new CostOfTheMonth(athlete).ShowDialog();
                }
            } 
            else throw new Exception("Either the sender is not a button, or the tag is not a Guid. This should never happen.");
        }

        private void NextPage_Click(object sender, EventArgs e)
        {
            page++;
            ChangePage();            
        }

        private void LastPage_Click(object sender, EventArgs e)
        {
            page--;
            ChangePage();            
        }

        private bool AtFirstPage() => page == 0;
        private bool AtLastPage() => page == athletes.Count / 25;
        private bool HasMultiplePages() => athletes.Count > 25;       

        private void ChangePage()
        {
            buttons.Clear();
            FlowPanel.Controls.Clear();

            //Display the athletes for the current page (25 athletes per page at most)
            for (int i = page * 25; i < Math.Min(page * 25 + 25, athletes.Count); i++)
            {
                FlowPanel.Controls.Add(CreateButton(AthleteStorage.Get(athletes[i])));
            }
            EnableButtons();
        }

        private Button CreateButton(Athlete athlete)
        {
            Button btn = new Button
            {
                Text = athlete.Name,
                Size = new Size(143, 61),
                Tag = athlete.Guid
            };

            //Subscribe to the click event of the button to handle editing/removing/viewing the athlete when clicked
            btn.Click += AthleteButton_Click; 
            buttons[athlete.Guid] = btn;
            return btn;
        }

        private void AddAthlete(Athlete athlete)
        {
            if (athletes.Count < page * 25 + 25) //Add a new button if the new athlete belongs on the current page
            {
                FlowPanel.Controls.Add(CreateButton(athlete));
            } 
            else if (AtFirstPage()) //If the new athlete belongs on a future page,
                                    //and we are currently on the first page,
                                    //enable the next page button since there is now a second page to navigate to
            {
                NextPage.Enabled = true;
            }

            athletes.Add(athlete.Guid);
            EnableButtons();
        }

        private void RemoveAthlete(Guid guid)
        {
            if (buttons.TryGetValue(guid, out Button btn))
            {
                AthleteStorage.Remove(guid);
                FlowPanel.Controls.Remove(btn);
                btn.Dispose();
                buttons.Remove(guid);
                athletes.Remove(guid);
            }
            else throw new Exception("There is no button for athlete with id " + guid + ". This should never happen.");            

            if (!AtLastPage()) //If there are athletes on future pages,
                               //move the first athlete from the next page to the current page to
                               //fill the gap left by the removed athlete
            {
                FlowPanel.Controls.Add(CreateButton(AthleteStorage.Get(athletes[page * 25 + 24])));
            }

            //Automatically exit remove/edit mode if there are no more athletes left,
            //or if the user has just removed the last athlete on the current page while in remove/edit mode
            if ((IsDeleting() && !AllowRemoveMode()) || (IsEditing() && !AllowEditMode()))
            {
                EnterMode(Mode.NONE);
            } 
            else EnableButtons(); //Otherwise just update the page button states in case the number of athletes has
                                  //dropped below 25

            //If the user has just removed the last athlete on the current page while on a future page,
            //move back a page to avoid displaying an empty page
            if (FlowPanel.Controls.Count == 0 && !AtFirstPage())
            {
                page--;
                ChangePage();
            }
        }

        private void EditAthlete(Athlete athlete)
        {
            if (buttons.TryGetValue(athlete.Guid, out Button btn))
            {
                btn.Text = athlete.Name;
            }
        }

        private bool IsDeleting() => mode == Mode.REMOVE;
        private bool IsEditing() => mode == Mode.EDIT;
       
        private bool AllowEditMode() => !AthleteStorage.IsEmpty() && !IsDeleting();
        private bool AllowRemoveMode() => !AthleteStorage.IsEmpty() && !IsEditing();

        private void EnterMode(Mode newMode)
        {
            mode = newMode;
            RemoveTipLabel.Visible = IsDeleting();
            EditTipLabel.Visible = IsEditing();
            EnableButtons();
        }

        private void EnableButtons()
        {
            NextPage.Enabled = HasMultiplePages() && !AtLastPage();
            LastPage.Enabled = HasMultiplePages() && !AtFirstPage();
            Register.Enabled = mode == Mode.NONE;
            Edit.Enabled = AllowEditMode();
            Remove.Enabled = AllowRemoveMode();
        }

        private enum Mode
        {
            NONE,            
            EDIT,
            REMOVE
        }
    }
}

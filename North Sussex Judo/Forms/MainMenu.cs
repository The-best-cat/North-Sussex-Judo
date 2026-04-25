using System;
using System.Drawing;
using System.Windows.Forms;

namespace NorthSussexJudo
{
    public partial class MainMenu : Form
    {
        private Mode mode = Mode.NONE;

        public MainMenu()
        {
            InitializeComponent();
            JsonManager.Load();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            foreach (var i in AthleteStorage.GetAll())
            {
                AddAthlete(i);
            }
            EnableButtons();
        }

        private void Register_Click(object sender, EventArgs e)
        {
            var form = new RegistrationForm();
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
                    {
                        RemoveAthlete(id);
                    }
                } 
                else if (IsEditing())
                {
                    var form = new EditForm(AthleteStorage.Get(id));
                    form.onEdited += (s, athlete) => EditAthlete(athlete);
                    form.ShowDialog();
                }
                else
                {
                    var athlete = AthleteStorage.Get(id);
                    new CostOfTheMonth(athlete).ShowDialog();
                }
            } 
            else
            {
                throw new Exception("Either the sender is not a button, or the tag is not a Guid. This should never happen.");
            }
        }

        private void AddAthlete(Athlete athlete)
        {
            Button btn = new Button();
            btn.Text = athlete.Name;
            btn.Size = new Size(143, 61);
            btn.Tag = athlete.Guid;
            btn.Click += AthleteButton_Click;
            FlowPanel.Controls.Add(btn);
            EnableButtons();
        }

        private void RemoveAthlete(Guid guid)
        {
            foreach (Control ctrl in FlowPanel.Controls) 
            {
                if (ctrl is Button btn && btn.Tag is Guid id && id == guid)
                {
                    AthleteStorage.Remove(guid);
                    FlowPanel.Controls.Remove(btn);
                    btn.Dispose();
                    break;
                }
            }
            EnableButtons();
        }

        private void EditAthlete(Athlete athlete)
        {
            foreach (Control ctrl in FlowPanel.Controls) 
            {
                if (ctrl is Button btn && btn.Tag is Guid id && id == athlete.Guid)
                {
                    btn.Text = athlete.Name;
                    break;
                }
            }
        }

        private void EnableButtons()
        {
            Remove.Enabled = !AthleteStorage.IsEmpty();
            Edit.Enabled = !AthleteStorage.IsEmpty();

            if ((IsDeleting() && !Remove.Enabled) || (IsEditing() && !Edit.Enabled))
            {
                EnterMode(Mode.NONE);
            }
        }

        private void EnterMode(Mode newMode)
        {
            mode = newMode;
            RemoveTipLabel.Visible = IsDeleting();
            EditTipLabel.Visible = IsEditing();
            OnModeChanged();
        }

        private void OnModeChanged()
        {
            Register.Enabled = mode == Mode.NONE;
            Edit.Enabled = (mode == Mode.NONE || IsEditing()) && !AthleteStorage.IsEmpty();
            Remove.Enabled = (mode == Mode.NONE || IsDeleting()) && !AthleteStorage.IsEmpty();
        }

        private bool IsDeleting()
        {
            return mode == Mode.REMOVE;
        }

        private bool IsEditing()
        {
            return mode == Mode.EDIT;
        }

        private enum Mode
        {
            NONE,            
            EDIT,
            REMOVE
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthSussexJudo
{
    public partial class EditForm : Form
    {
        public event EventHandler<Athlete> onEdited;

        private Athlete athlete;

        public EditForm(Athlete athlete)
        {
            this.athlete = athlete;
            InitializeComponent();
        }

        private void EditForm_Load(object sender, EventArgs e)
        {
            TrainingPlanList.Items.AddRange(TrainingPlans.GetPlans().ConvertAll(plan => plan.Name).ToArray());
            WeightCatList.Items.AddRange(WeightCategories.GetCategories().ConvertAll(cat => cat.Name).ToArray());

            NameBox.Text = athlete.Name;
            TrainingPlanList.SelectedIndex = TrainingPlanList.Items.IndexOf(athlete.Outcome.Plan.Name);
            WeightBox.Text = athlete.Weight.ToString();
            WeightCatList.SelectedIndex = WeightCatList.Items.IndexOf(athlete.WeightCategory.Name);
            CompetitionBox.Text = athlete.Outcome.Competitions.Item1.ToString();
            CoachingHourList.SelectedIndex = athlete.Outcome.CoachingHours.Item1;            
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            if (!CheckAllowRegister()) return;

            Athlete athlete = new Athlete(
                this.athlete.Guid,
                NameBox.Text,
                TrainingPlans.GetPlan(TrainingPlanList.Text),
                float.TryParse(WeightBox.Text, out float weight) ? weight : throw new ArgumentException("Weight needs to be a floating point number."),
                WeightCategories.GetCategory(WeightCatList.Text),
                int.TryParse(CompetitionBox.Text, out int competitions) ? competitions : throw new ArgumentException("Number of competitions needs to be an integer."),
                CoachingHourList.SelectedIndex
            );

            AthleteStorage.Register(athlete);
            onEdited?.Invoke(this, athlete);

            Hide();
            new CostOfTheMonth(athlete).ShowDialog();
            Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void NameBox_Validating(object sender, CancelEventArgs e)
        {
            Validation.ValidateName(e, NameBox, NameError);
        }

        private void WeightBox_TextChanged(object sender, EventArgs e)
        {
            Validation.FilterInvalidInput(WeightBox);
        }

        private void CompetitionBox_TextChanged(object sender, EventArgs e)
        {
            Validation.FilterInvalidInput(CompetitionBox);
        }

        private void WeightBox_Validating(object sender, CancelEventArgs e)
        {
            Validation.HandleInvalidFloat(e, WeightBox, WeightError, "Please enter a valid weight.");
        }

        private void CompetitionBox_Validating(object sender, CancelEventArgs e)
        {
            Validation.HandleInvalidInt(e, CompetitionBox, CompetitionError, "Please enter a valid number of competitions.");
        }

        private void TrainingPlanList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CompetitionBox.Enabled = TrainingPlans.GetPlan(TrainingPlanList.Text).AllowCompetition;
        }

        private bool CheckAllowRegister()
        {
            bool valid = true;

            if (string.IsNullOrEmpty(NameBox.Text))
            {
                valid = false;
                NameError.SetError(NameBox, "Pleaase enter the athlete's name.");
            }

            valid = valid && Validation.IsNameValid(NameBox);

            if (TrainingPlanList.SelectedIndex == -1)
            {
                valid = false;
                PlanError.SetError(TrainingPlanList, "Please select a training plan.");
            }

            valid = valid && Validation.ValidateFloatInput(WeightBox);

            if (WeightCatList.SelectedIndex == -1)
            {
                valid = false;
                CatError.SetError(WeightCatList, "Please select a weight category.");
            }

            valid = valid && Validation.ValidateIntInput(CompetitionBox);

            return valid;
        }
    }
}

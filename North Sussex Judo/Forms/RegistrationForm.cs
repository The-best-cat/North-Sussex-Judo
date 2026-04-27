using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace NorthSussexJudo
{
    public partial class RegistrationForm : Form
    {
        public event EventHandler<Athlete> onRegistered;        

        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void RegistrationForm_Load(object sender, EventArgs e)
        {
            TrainingPlanList.Items.AddRange(TrainingPlans.GetPlans().ConvertAll(plan => plan.Name).ToArray());
            WeightCatList.Items.AddRange(WeightCategories.GetCategories().ConvertAll(cat => cat.Name).ToArray());
            CoachingHourList.SelectedIndex = 0;
        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            if (!CheckAllowRegister()) return;

            Athlete athlete = new Athlete(
                Guid.NewGuid(),
                NameBox.Text,
                TrainingPlans.GetPlan(TrainingPlanList.Text),
                float.TryParse(WeightBox.Text, out float weight) ? weight : throw new ArgumentException("Weight needs to be a floating point number."),
                WeightCategories.GetCategory(WeightCatList.Text),
                int.TryParse(CompetitionBox.Text, out int competitions) ? competitions : throw new ArgumentException("Number of competitions needs to be an integer."),
                CoachingHourList.SelectedIndex
            );

            AthleteStorage.Register(athlete);
            onRegistered?.Invoke(this, athlete);

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
            if (Validation.ValidateDropdown(TrainingPlanList, PlanError))
            {
                CompetitionBox.Enabled = TrainingPlans.GetPlan(TrainingPlanList.Text).AllowCompetition;
            }
        }

        private void WeightCatList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Validation.ValidateDropdown(WeightCatList, CatError);
        }

        private bool CheckAllowRegister()
        {
            return Validation.CheckAllowRegister(
                NameBox,
                WeightBox,
                CompetitionBox,
                TrainingPlanList,
                WeightCatList,
                NameError,
                PlanError,
                CatError
            );
        }
    }
}

using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace NorthSussexJudo
{
    public partial class RegistrationForm : Form
    {
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
                NameBox.Text,
                TrainingPlans.GetPlan(TrainingPlanList.SelectedIndex),
                float.TryParse(WeightBox.Text, out float weight) ? weight : throw new ArgumentException("Weight needs to be a floating point number."),
                WeightCategories.GetCategory(WeightCatList.SelectedIndex),
                int.TryParse(CompetitionBox.Text, out int competitions) ? competitions : throw new ArgumentException("Number of competitions needs to be an integer."),
                CoachingHourList.SelectedIndex
            );

            athlete.UpdateOutcome();
            AthleteStorage.Register(athlete);

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
            if (!ValidateName())
            {
                e.Cancel = true;
                NameBox.Focus();
                NameError.SetError(NameBox, "Please enter a valid name (letters and spaces only).");
            }
            else
            {
                NameError.SetError(NameBox, string.Empty);
            }
        }

        private void WeightBox_TextChanged(object sender, EventArgs e)
        {
            FilterInvalidInput(WeightBox);
        }

        private void CompetitionBox_TextChanged(object sender, EventArgs e)
        {
            FilterInvalidInput(CompetitionBox);
        }

        private void WeightBox_Validating(object sender, CancelEventArgs e)
        {
            HandleInvalidInput(sender, e, WeightBox, WeightError, "Please enter a valid weight.");
        }

        private void CompetitionBox_Validating(object sender, CancelEventArgs e)
        {
            HandleInvalidInput(sender, e, CompetitionBox, CompetitionError, "Please enter a valid number of competitions.");
        }

        private void TrainingPlanList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CompetitionBox.Enabled = TrainingPlans.GetPlan(TrainingPlanList.SelectedIndex).AllowCompetition;
        }

        private bool ValidateName()
        {
            foreach (char c in NameBox.Text)
            {
                if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                {
                    return false;
                }
            }
            return true;
        }

        private bool ValidateNumericInput(TextBox textBox)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "0";
            }
            
            foreach (char c in textBox.Text)
            {
                if (!char.IsDigit(c) && c != '.' && c != ',')
                {
                    return false;
                }
            }

            return float.TryParse(textBox.Text, out _);
        }

        private void HandleInvalidInput(object sender, CancelEventArgs e, TextBox textBox, ErrorProvider provider, string message)
        {
            if (!ValidateNumericInput(textBox))
            {
                e.Cancel = true;
                textBox.Focus();
                provider.SetError(textBox, message);
            }
            else
            {
                provider.SetError(textBox, string.Empty);
            }
        }

        private void FilterInvalidInput(TextBox textBox)
        {
            StringBuilder sb = new StringBuilder();
            
            foreach (char c in textBox.Text)
            {
                if (char.IsDigit(c) || c == '.' || c == ',')
                {
                    sb.Append(c);
                }
            }

            textBox.Text = sb.ToString();
        }

        private bool CheckAllowRegister()
        {
            bool valid = true;

            if (string.IsNullOrEmpty(NameBox.Text))
            {
                valid = false;
                NameError.SetError(NameBox, "Pleaase enter the athlete's name.");
            }

            valid = valid && ValidateName();

            if (TrainingPlanList.SelectedIndex == -1)
            {
                valid = false;
                PlanError.SetError(TrainingPlanList, "Please select a training plan.");
            }

            valid = valid && ValidateNumericInput(WeightBox);

            if (WeightCatList.SelectedIndex == -1)
            {
                valid = false;
                CatError.SetError(WeightCatList, "Please select a weight category.");
            }

            valid = valid && ValidateNumericInput(CompetitionBox);

            return valid;
        }
    }
}

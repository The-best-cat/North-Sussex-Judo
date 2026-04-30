using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NorthSussexJudo
{
    public static class Validation
    {
        //Validate name input to ensure it only contains letters and spaces, and is not empty or whitespace only
        public static bool IsNameValid(TextBox box)
        {
            return !box.Text.Any(c => !char.IsLetter(c) && !char.IsWhiteSpace(c)) 
                && !box.Text.All(char.IsWhiteSpace);
        }

        //Filter out any non-numeric characters from the input, allowing only digits, decimal points, and commas
        public static void FilterInvalidInput(TextBox textBox)
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

        //Validate name input and provide user feedback through an ErrorProvider if the input is invalid
        public static void ValidateName(CancelEventArgs e, TextBox box, ErrorProvider error)
        {
            if (!IsNameValid(box))
            {
                e.Cancel = true;
                box.Focus(); //Force the user to correct the input before moving on
                error.SetError(box, "Please enter a valid name (letters and spaces only).");
            }
            else
            {
                TrimName(box);
                error.SetError(box, string.Empty);
            }
        }

        //Validate that a selection has been made in a dropdown list
        //and provide user feedback through an ErrorProvider if no selection is made
        public static bool ValidateDropdown(ComboBox box, ErrorProvider error, string message = "")
        {
            if (box.SelectedIndex == -1)
            {                
                error.SetError(box, message);
                return false;
            }
            error.SetError(box, string.Empty);
            return true;
        }

        //Trim leading and trailing whitespace from the input, and reduce multiple consecutive spaces to a single space
        private static void TrimName(TextBox textBox)
        {
            StringBuilder sb = new StringBuilder();
            textBox.Text = textBox.Text.Trim();

            for (int i = 0; i < textBox.Text.Length; i++)
            {
                char c = textBox.Text[i];                
                if (char.IsLetter(c) || char.IsWhiteSpace(c))
                {
                    //skip if the previous character is also a whitespace
                    if (char.IsWhiteSpace(c) && i > 0 && char.IsWhiteSpace(textBox.Text[i - 1]))                    
                        continue;                                       
                } 
                else continue;                
                sb.Append(c);
            }
            textBox.Text = sb.ToString();
        }

        public static bool ValidateFloatInput(TextBox textBox)
        {
            return IsNumeric(textBox) && float.TryParse(textBox.Text, out float result) && result >= 0;
        }

        public static bool ValidateIntInput(TextBox textBox)
        {
            return IsNumeric(textBox) && int.TryParse(textBox.Text, out int result) && result >= 0;
        }

        //Check if the input contains only digits, decimal points, and commas
        //If the input is empty, set it to "0" first
        private static bool IsNumeric(TextBox textBox)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = "0";
            }
            return !textBox.Text.Any(c => !char.IsDigit(c) && c != '.' && c != ',');
        }

        //Validate float input and provide user feedback through an ErrorProvider if the input is invalid
        public static void HandleInvalidFloat(CancelEventArgs e, TextBox textBox, ErrorProvider provider, string message)
        {
            if (!ValidateFloatInput(textBox))
            {
                e.Cancel = true;
                textBox.Focus();
                provider.SetError(textBox, message);
            }
            else provider.SetError(textBox, string.Empty);
        }

        //Validate int input and provide user feedback through an ErrorProvider if the input is invalid
        public static void HandleInvalidInt(CancelEventArgs e, TextBox textBox, ErrorProvider provider, string message)
        {
            if (!ValidateIntInput(textBox))
            {
                e.Cancel = true;
                textBox.Focus();
                provider.SetError(textBox, message);
            }
            else provider.SetError(textBox, string.Empty);
        }

        //Check if all required fields are valid for registering an athlete,
        //and provide user feedback through ErrorProviders for any invalid fields
        public static bool CheckAllowRegister(TextBox name, TextBox weight, TextBox competition, ComboBox trainingPlanList,
            ComboBox weightCatList, ErrorProvider nameError, ErrorProvider planError, ErrorProvider catError
        )
        {
            bool valid = true;

            if (string.IsNullOrEmpty(name.Text))
            {
                valid = false;
                nameError.SetError(name, "Please enter the athlete's name.");
            } 
            else nameError.SetError(name, string.Empty);

            valid = valid && IsNameValid(name);
            valid = valid && ValidateDropdown(trainingPlanList, planError, "Please select a training plan.");
            valid = valid && ValidateFloatInput(weight);
            valid = valid && ValidateDropdown(weightCatList, catError, "Please select a weight category.");
            valid = valid && ValidateIntInput(competition);

            return valid;
        }
    }
}

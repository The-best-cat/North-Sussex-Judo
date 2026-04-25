using NorthSussexJudo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthSussexJudo
{
    public static class Validation
    {
        public static bool IsNameValid(TextBox box)
        {
            foreach (char c in box.Text)
            {
                if (!char.IsLetter(c) && !char.IsWhiteSpace(c))
                {
                    return false;
                }
            }
            return !box.Text.All(char.IsWhiteSpace);
        }

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

        public static void ValidateName(CancelEventArgs e, TextBox box, ErrorProvider error)
        {
            if (!IsNameValid(box))
            {
                e.Cancel = true;
                box.Focus();
                error.SetError(box, "Please enter a valid name (letters and spaces only).");
            }
            else
            {
                TrimName(box);
                error.SetError(box, string.Empty);
            }
        }

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

        private static void TrimName(TextBox textBox)
        {
            StringBuilder sb = new StringBuilder();
            textBox.Text = textBox.Text.Trim();

            for (int i = 0; i < textBox.Text.Length; i++)
            {
                char c = textBox.Text[i];
                if (char.IsLetter(c))
                {
                    sb.Append(c);
                    continue;
                }
                else if (char.IsWhiteSpace(c))
                {
                    if (i > 0 && char.IsWhiteSpace(textBox.Text[i - 1]))
                    {
                        continue;
                    }
                    sb.Append(c);
                }
            }
            textBox.Text = sb.ToString();
        }

        public static bool ValidateFloatInput(TextBox textBox)
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

            return float.TryParse(textBox.Text, out float result) && result >= 0;
        }

        public static bool ValidateIntInput(TextBox textBox)
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

            return int.TryParse(textBox.Text, out int result) && result >= 0;
        }

        public static void HandleInvalidFloat(CancelEventArgs e, TextBox textBox, ErrorProvider provider, string message)
        {
            if (!ValidateFloatInput(textBox))
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
        public static void HandleInvalidInt(CancelEventArgs e, TextBox textBox, ErrorProvider provider, string message)
        {
            if (!ValidateIntInput(textBox))
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

        public static bool CheckAllowRegister(TextBox name, TextBox weight, TextBox competition, ComboBox trainingPlanList,
            ComboBox weightCatList, ErrorProvider nameError, ErrorProvider planError, ErrorProvider catError
        )
        {
            bool valid = true;

            if (string.IsNullOrEmpty(name.Text))
            {
                valid = false;
                nameError.SetError(name, "Pleaase enter the athlete's name.");
            } 
            else
            {
                nameError.SetError(name, string.Empty);
            }

            valid = valid && IsNameValid(name);
            valid = valid && ValidateDropdown(trainingPlanList, planError, "Please select a training plan.");
            valid = valid && ValidateFloatInput(weight);
            valid = valid && ValidateDropdown(weightCatList, catError, "Please select a weight category.");
            valid = valid && ValidateIntInput(competition);

            return valid;
        }
    }
}

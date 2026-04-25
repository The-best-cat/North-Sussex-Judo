using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NorthSussexJudo
{
    public partial class CostOfTheMonth : Form
    {
        private const int Y_GAP = 16;
        private const int EXTRA_X_GAP = 16;
        private const int EXTRA_Y_GAP = 5;

        private readonly Athlete athlete;

        public CostOfTheMonth(Athlete athlete)
        {
            this.athlete = athlete;
            InitializeComponent();
        }

        private void CostOfTheMonth_Load(object sender, EventArgs e)
        {
            NameDisplay.Text = athlete.Name;
            WeightDisplay.Text = athlete.Weight.ToString() + "kg";
            CategoryDisplay.Text = athlete.WeightCategory.Name;
            AnalysisDisplay.Text = WeightCategories.Analyse(athlete.Weight, athlete.WeightCategory);

            int leftX = PlanDisplay.Location.X;
            int rightX = PlanCostDisplay.Location.X;
            int width = PlanCostDisplay.Width;
            int height = PlanDisplay.Height;
            int currentY = PlanDisplay.Location.Y + Y_GAP;

            decimal finalCost = 0m;
            
            var outcome = athlete.Outcome;

            finalCost += outcome.Plan.Cost * 4;
            PlanDisplay.Text = outcome.Plan.Name + " Training Plan";
            PlanCostDisplay.Text = "£" + finalCost.ToString("0.00");

            if (outcome.Competitions.Item1 > 0)
            {
                finalCost += outcome.Competitions.Item2;

                ItemLabel("Competition x" + outcome.Competitions.Item1, leftX, currentY, height);
                CostLabel("£" + outcome.Competitions.Item2.ToString("0.00"), rightX, currentY, width, height);

                currentY += Y_GAP;
            }

            if (outcome.CoachingHours.Item1 > 0)
            {
                finalCost += outcome.CoachingHours.Item2 * 4;

                ItemLabel($"Private Coaching {outcome.CoachingHours.Item1 * 4}hr", leftX, currentY, height);
                CostLabel("£" + (outcome.CoachingHours.Item2 * 4).ToString("0.00"), rightX, currentY, width, height);

                currentY += Y_GAP;
            }

            Label total = new Label();
            total.Text = "Total";
            total.Font = new Font(total.Font, FontStyle.Bold);
            total.Location = new Point(leftX + EXTRA_X_GAP, currentY + EXTRA_Y_GAP);
            Controls.Add(total);

            CostLabel("£" + finalCost.ToString("0.00"), rightX, currentY + EXTRA_Y_GAP, width, height);
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ItemLabel(string text, int x, int y, int h)
        {
            Label label = new Label
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(200, h),
                BackColor = Color.Transparent
            };
            Controls.Add(label);
        }

        private void CostLabel(string text, int x, int y, int w, int h)
        {
            Label label = new Label
            {
                Text = text,
                Location = new Point(x, y),
                Size = new Size(w, h),
                TextAlign = ContentAlignment.TopRight,
                BackColor = Color.Transparent
            };
            Controls.Add(label);
        }
    }
}

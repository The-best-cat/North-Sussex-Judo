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
    public partial class CostOfTheMonth : Form
    {
        private const int Y_GAP = 16;
        private const int EXTRA_X_GAP = 16;
        private const int EXTRA_Y_GAP = 5;

        private Athlete athlete;

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
            int currentY = PlanDisplay.Location.Y + Y_GAP;

            decimal finalCost = 0m;

            var costSize = PlanCostDisplay.Size;
            var outcome = athlete.Outcome;

            finalCost += outcome.Plan.Cost * 4;
            PlanDisplay.Text = outcome.Plan.Name + " Training Plan";
            PlanCostDisplay.Text = "£" + finalCost.ToString("0.00");

            if (outcome.Competitions.Item1 > 0)
            {
                finalCost += outcome.Competitions.Item2;

                Label competition = new Label();
                competition.Text = "Competition x" + outcome.Competitions.Item1;
                competition.Location = new Point(leftX, currentY);
                competition.Size = costSize;                
                Controls.Add(competition);                

                Label competitionCost = new Label();
                competitionCost.Text = "£" + outcome.Competitions.Item2.ToString("0.00");
                competitionCost.Location = new Point(rightX, currentY);
                competitionCost.Size = costSize;
                competitionCost.TextAlign = ContentAlignment.TopRight;
                Controls.Add(competitionCost);

                currentY += Y_GAP;
            }

            if (outcome.CoachingHours.Item1 > 0)
            {
                finalCost += outcome.CoachingHours.Item2;

                Label coaching = new Label();
                coaching.Text = $"Private Coaching {outcome.CoachingHours.Item1}hr";
                coaching.Location = new Point(leftX, currentY);
                coaching.Size = new Size(200, costSize.Height);                
                Controls.Add(coaching);

                Label coachingCost = new Label();
                coachingCost.Text = "£" + outcome.CoachingHours.Item2.ToString("0.00");
                coachingCost.Location = new Point(rightX, currentY);
                coachingCost.Size = costSize;
                coachingCost.TextAlign = ContentAlignment.TopRight;
                Controls.Add(coachingCost);
            }

            Label total = new Label();
            total.Text = "Total";
            total.Font = new Font(total.Font, FontStyle.Bold);
            total.Location = new Point(leftX + EXTRA_X_GAP, currentY + Y_GAP + EXTRA_Y_GAP);
            Controls.Add(total);

            Label final = new Label();
            final.Text = "£" + finalCost.ToString("0.00");
            final.Location = new Point(rightX, currentY + Y_GAP + EXTRA_Y_GAP);
            final.Size = costSize;
            final.TextAlign = ContentAlignment.TopRight;
            Controls.Add(final);
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

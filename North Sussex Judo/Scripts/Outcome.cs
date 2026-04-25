using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthSussexJudo
{
    //Stores the outcome so old records remain accurate to what was actually charged at the time
    // regardless of any future changes to the costs.
    //Doesn't store the weights as they should be updated in real time.
    public struct Outcome 
    {
        public TrainingPlan Plan { get; private set; } //weekly cost
        public (int, decimal) Competitions { get; private set; } //(number of competitions, cost), monthly cost
        public (int, decimal) CoachingHours { get; private set; } //(number of hours, cost), weekly cost
        public DateTime Date { get; private set; } //date of registration

        public Outcome(TrainingPlan plan, int competitions, int coachingHours)
        {
            Plan = plan;
            Competitions = (competitions, competitions * Costs.PER_COMPETITION);
            CoachingHours = (coachingHours, coachingHours * Costs.COACHING_PER_HOUR);
            Date = DateTime.Now;
        }

        [JsonConstructor]
        public Outcome(TrainingPlan plan, (int, decimal) competitions, (int, decimal) coachingHours, DateTime date)
        {
            Plan = plan;
            Competitions = competitions;
            CoachingHours = coachingHours;
            Date = date;
        }
    }
}

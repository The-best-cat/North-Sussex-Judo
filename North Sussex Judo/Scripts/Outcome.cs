using Newtonsoft.Json;
using System;

namespace NorthSussexJudo
{
    //Stores the outcome so old records remain accurate to what was actually charged at the time
    //regardless of any future changes to the costs.
    //Doesn't store the weights as they should be updated in real time.
    public struct Outcome 
    {
        public TrainingPlan Plan { get; } //weekly cost
        public (int, decimal) Competitions { get; } //(number of competitions, cost), monthly cost
        public (int, decimal) CoachingHours { get; } //(number of hours, cost), weekly cost
        public DateTime Date { get; } //date of registration

        public Outcome(TrainingPlan plan, int competitions, int coachingHours)
        {
            Plan = plan;
            Competitions = (competitions, competitions * Constants.PER_COMPETITION);
            CoachingHours = (coachingHours, coachingHours * Constants.COACHING_PER_HOUR);
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

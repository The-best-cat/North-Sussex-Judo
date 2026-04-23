namespace NorthSussexJudo
{
    public class Athlete
    {
        public string Name { get; private set; }
        public TrainingPlan Plan { get; private set; }
        public float Weight { get; private set; }
        public WeightCategory WeightCategory { get; private set; }
        public int Competitions { get; private set; }
        public int PrivateCoachingHours { get; private set; } 
        public Outcome Outcome { get; private set; }

        public Athlete(string name, TrainingPlan plan, float weight, WeightCategory category, int competitions, 
            int privateCoachingHours)
        {
            Name = name;
            Plan = plan;
            Weight = weight;
            WeightCategory = category;
            Competitions = competitions;
            PrivateCoachingHours = privateCoachingHours;
        }

        public Outcome UpdateOutcome()
        {
            Outcome = new Outcome(Plan, Competitions, PrivateCoachingHours);
            return Outcome;
        }
    }
}

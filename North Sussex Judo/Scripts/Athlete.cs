using Newtonsoft.Json;
using System;

namespace NorthSussexJudo
{
    public class Athlete
    {
        public Guid Guid { get; private set; }
        public string Name { get; private set; }        
        public float Weight { get; private set; }
        public WeightCategory WeightCategory { get; private set; }        
        public Outcome Outcome { get; private set; }

        public Athlete(Guid guid, string name, TrainingPlan plan, float weight, WeightCategory category, int competitions, 
            int privateCoachingHours)
        {
            Guid = guid;
            Name = name;
            Weight = weight;
            WeightCategory = category;
            UpdateOutcome(plan, competitions, privateCoachingHours);
        }

        [JsonConstructor]
        public Athlete(Guid guid, string name, float weight, WeightCategory weightCategory, Outcome outcome)
        {
            Guid = guid;
            Name = name;
            Weight = weight;
            WeightCategory = WeightCategories.GetCategory(weightCategory.Name);
            Outcome = outcome;
        }

        private Outcome UpdateOutcome(TrainingPlan plan, int competitions, int privateCoachingHours)
        {
            Outcome = new Outcome(plan, competitions, privateCoachingHours);
            return Outcome;
        }
    }
}

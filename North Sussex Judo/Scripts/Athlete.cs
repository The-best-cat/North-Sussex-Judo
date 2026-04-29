using Newtonsoft.Json;
using System;

namespace NorthSussexJudo
{
    public class Athlete
    {
        public Guid Guid { get; }
        public string Name { get; }        
        public float Weight { get; }
        public WeightCategory WeightCategory { get; }        
        public Outcome Outcome { get; private set; }

        public Athlete(Guid guid, string name, TrainingPlan plan, float weight, WeightCategory category, int competitions, 
            int privateCoachingHours)
        {
            Guid = guid;
            Name = name;
            Weight = weight;
            WeightCategory = category;
            Outcome = new Outcome(plan, competitions, privateCoachingHours);
        }
    }
}

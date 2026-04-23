using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthSussexJudo
{
    public struct TrainingPlan 
    {
        public string Name { get; private set; }
        public decimal Cost { get; private set; }
        public bool AllowCompetition { get; private set; }

        public TrainingPlan(string name, decimal cost, bool allowCompetition)
        {
            Name = name;
            Cost = cost;
            AllowCompetition = allowCompetition;
        }
    }

    internal static class TrainingPlans
    {
        private static readonly List<TrainingPlan> trainingPlans = new List<TrainingPlan>();

        public static readonly TrainingPlan BEGINNER = Register("Beginner", Costs.BEGINNER, false);
        public static readonly TrainingPlan INTERMEDIATE = Register("Intermediate", Costs.INTERMEDIATE);
        public static readonly TrainingPlan ELITE = Register("Elite", Costs.ELITE);

        public static List<TrainingPlan> GetPlans()
        {
            return trainingPlans.ToList();
        }

        public static TrainingPlan GetPlan(int index)
        {
            return trainingPlans[index];
        }

        private static TrainingPlan Register(string name, decimal cost, bool allowCompetition = true)
        {
            var plan = new TrainingPlan(name, cost, allowCompetition);
            trainingPlans.Add(plan);
            return plan;
        }
    }
}

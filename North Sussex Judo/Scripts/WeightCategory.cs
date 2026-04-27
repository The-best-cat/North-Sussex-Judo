using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NorthSussexJudo
{
    public class WeightCategory 
    {
        public string Name { get; private set; }
        public float Limit { get; private set; }

        [JsonConstructor]
        public WeightCategory(string name, float limit)
        {
            Name = name;
            Limit = limit;
        }
    }

    internal static class WeightCategories 
    {
        private static readonly List<WeightCategory> categories = new List<WeightCategory>();

        public static readonly WeightCategory HEAVY = Register("Heavy", int.MaxValue); 
        public static readonly WeightCategory LIGHT_HEAVY = Register("Light Heavy", 100);
        public static readonly WeightCategory MIDDLE = Register("Middle", 90);
        public static readonly WeightCategory LIGHT_MIDDLE = Register("Light Middle", 81);
        public static readonly WeightCategory LIGHT = Register("Light", 73); 
        public static readonly WeightCategory FLY = Register("Fly", 66);

        public static List<WeightCategory> GetCategories() => categories.ToList();
        public static WeightCategory GetCategory(string name) => categories.FirstOrDefault(c => c.Name.Equals(name));

        public static string Analyse(float weight, WeightCategory category)
        {
            //Finds the category the athlete should be in based on their weight
            //Default to FLY
            WeightCategory supposedCat = categories.LastOrDefault(c => c.Limit <= weight) ?? FLY;            

            if (category.Equals(HEAVY))
            {
                if (weight > 100)
                    return "Requirement of over 100kg has been met for this athlete.";
                else if (weight == 100)
                    return "This athlete is right below the required 100kg lower limit.";
                else
                    return $"This athlete is {(100f - weight).ToString("0.##")}kg below the required 100kg lower limit.";
            }
            else
            {
                float difference = category.Limit - weight;
                if (difference < 0)
                {
                    return $"This athlete is {Math.Abs(difference).ToString("0.##")}kg too heavy for this category.";
                }
                else if (difference > 0)
                {
                    if (!supposedCat.Equals(category))                    
                        return $"This athlete is too light. They should be in the {supposedCat.Name} category.";
                    else                    
                        return $"This athlete meets the weight requirement for this category and is {difference}kg below the upper limit.";                    
                }
                return "This athlete is right at the upper limit.";
            }
        }

        private static WeightCategory Register(string name, float limit)
        {
            var category = new WeightCategory(name, limit);
            categories.Add(category);
            return category;
        }
    }
}

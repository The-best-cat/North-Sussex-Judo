using System;
using System.Collections.Generic;
using System.Linq;

namespace NorthSussexJudo
{
    internal static class AthleteStorage
    {
        private static readonly Dictionary<Guid, Athlete> athletes = new Dictionary<Guid, Athlete>();

        public static void Register(Athlete athlete)
        {
            if (athlete == null) throw new ArgumentNullException("Athlete data is null.");

            if (string.IsNullOrEmpty(athlete.Name)) throw new ArgumentException("Athlete name cannot be empty.");

            athletes[athlete.Guid] = athlete; //This will add or override the athlete based on the Guid key   
        }

        public static bool Remove(Guid id)
        {
            return athletes.Remove(id);
        }

        public static Athlete Get(Guid id)
        {
            if (athletes.TryGetValue(id, out Athlete athlete))
            {
                return athlete;
            }
            throw new KeyNotFoundException($"Athlete with ID {id} does not exist.");
        }

        public static List<Athlete> GetAll() => athletes.Values.ToList();
        public static bool IsEmpty() => athletes.Count == 0;
    }
}

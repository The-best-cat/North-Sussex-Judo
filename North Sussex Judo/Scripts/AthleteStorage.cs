using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthSussexJudo
{
    internal static class AthleteStorage
    {
        private static readonly Dictionary<Guid, Athlete> athletes = new Dictionary<Guid, Athlete>();

        public static void Register(Athlete athlete)
        {
            if (athlete == null) throw new ArgumentNullException("Athlete data is null.");

            if (string.IsNullOrEmpty(athlete.Name)) throw new ArgumentException("Athlete name cannot be empty.");

            athletes[athlete.Guid] = athlete;            
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

        public static List<Athlete> GetAll()
        {
            return athletes.Values.ToList();
        }

        public static bool IsEmpty()
        {
            return athletes.Count == 0;
        }
    }
}

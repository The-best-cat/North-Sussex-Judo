using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace NorthSussexJudo
{
    internal static class JsonManager
    {
        public const string FOLDER_NAME = "North Sussex Judo";
        public const string FILE_NAME = "athletes.json";

        public static void Save()
        {
            string json = JsonConvert.SerializeObject(AthleteStorage.GetAll());

            var file = File.Create(GetPath());
            using (StreamWriter writer = new StreamWriter(file))
            {
                writer.Write(json);
            }
        }

        public static void Load()
        {
            if (File.Exists(GetPath()))
            {
                string json = File.ReadAllText(GetPath());
                
                var settings = new JsonSerializerSettings
                {
                    Error = (sender, args) =>
                    {                        
                        args.ErrorContext.Handled = true;
                    }
                };

                List<Athlete> athletes = JsonConvert.DeserializeObject<List<Athlete>>(json, settings);
                if (athletes != null)
                {
                    foreach (var i in athletes)
                    {
                        if (i.WeightCategory != null
                            && i.Outcome.Plan != null
                            && (i.Outcome.Competitions.Item1 > 0) == (i.Outcome.Competitions.Item2 > 0)
                            && (i.Outcome.CoachingHours.Item1 > 0) == (i.Outcome.CoachingHours.Item2 > 0)
                        )
                        {
                            AthleteStorage.Register(i);
                        }
                    }
                }
            }
        }

        private static string GetDirectory()
        {
            string directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), FOLDER_NAME);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            return directory;
        }

        private static string GetPath()
        {
            return Path.Combine(GetDirectory(), FILE_NAME);
        }
    }
}

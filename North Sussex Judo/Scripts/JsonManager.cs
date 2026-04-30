using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
            using (StreamWriter writer = new StreamWriter(file)) //WriteAllText can cause issues with file locks,
                                                                 //so use StreamWriter instead
            {
                writer.Write(json);
            }
        }

        public static void Load()
        {
            if (File.Exists(GetPath()))
            {
                string json = File.ReadAllText(GetPath());

                //Ignore errors during deserialization, so that one bad athlete doesn't prevent the rest from loading
                var settings = new JsonSerializerSettings 
                {
                    Error = (sender, args) =>
                    {                        
                        args.ErrorContext.Handled = true;
                    }
                };

                List<Athlete> athletes = JsonConvert.DeserializeObject<List<Athlete>>(json, settings);
                if (athletes != null) //If the file is empty or the json is invalid, the list will be null
                {
                    foreach (var i in athletes)
                    {
                        //Only register athletes that have valid data, to prevent issues with the rest of the program
                        if (i.WeightCategory != null
                            && i.Outcome.Plan != null
                            && (i.Outcome.Competitions.Item1 > 0) == (i.Outcome.Competitions.Item2 > 0) //Both are either greater than 0 or both are 0, otherwise the data is invalid
                            && (i.Outcome.CoachingHours.Item1 > 0) == (i.Outcome.CoachingHours.Item2 > 0) //Both are either greater than 0 or both are 0, otherwise the data is invalid
                        )
                        {
                            AthleteStorage.Register(i);
                        }
                    }
                }
            }
        }

        //Ensure the directory for the JSON file exists and return the path to the directory
        private static string GetDirectory()
        {
            string directory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), FOLDER_NAME);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            return directory;
        }

        private static string GetPath() => Path.Combine(GetDirectory(), FILE_NAME);
    }
}

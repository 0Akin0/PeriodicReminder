using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriodicReminder {
    public class ReminderTextFileConn {

        private string ReminderPath { get { return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "My Programm Data", "ThingsToRemember.txt"); } }

        public List<ThingToRemember> GetThingsToRemember() {
            string[] fileContent = File.ReadAllLines(ReminderPath);
            List<ThingToRemember> thingsToRemember = new List<ThingToRemember>();

            foreach (var line in fileContent) {
                string[] items = line.Split(';');
                ThingToRemember thing = new ThingToRemember {
                    Name = items[0],
                    Description = items[1],
                    DurationMin = int.Parse(items[2])
                };

                thingsToRemember.Add(thing);
            }

            return thingsToRemember;
        }

        public void SaveThingsToRemember(List<ThingToRemember> thingsToRemember) {
            string fileContent = string.Empty;

            foreach (var item in thingsToRemember) {
                fileContent += $"{item.Name};{item.Description};{item.DurationMin}\n";
            }

            File.WriteAllText(ReminderPath, fileContent);
        }
    }
}

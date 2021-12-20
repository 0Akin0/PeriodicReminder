using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeriodicReminder {
    public class ReminderTextFileConn {
        const int NameIndexInFile = 0;
        const int DescriptionIndexInFile = 1;
        const int DurationIndexInFile = 2;
        const int DisabledIndexInFile = 3;
        private string ReminderPath { get { return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "My Programm Data", "ThingsToRemember.txt"); } }

        public ReminderTextFileConn() {
            if (!File.Exists(ReminderPath)) {
                File.WriteAllText(ReminderPath, string.Empty);
            }
        }

        public List<ThingToRemember> GetThingsToRemember() {
            string[] fileContent = File.ReadAllLines(ReminderPath);
            List<ThingToRemember> thingsToRemember = new List<ThingToRemember>();

            foreach (var line in fileContent) {
                if (!string.IsNullOrEmpty(line)) {
                    string[] items = line.Split(';');
                    ThingToRemember thing = new ThingToRemember {
                        Name = items[NameIndexInFile],
                        Description = items[DescriptionIndexInFile],
                        DurationMin = int.Parse(items[DurationIndexInFile]),
                        Disabled = bool.Parse(items[DisabledIndexInFile])
                    };

                    thingsToRemember.Add(thing);
                }
            }

            return thingsToRemember;
        }

        public void SaveThingsToRemember(List<ThingToRemember> thingsToRemember) {
            string fileContent = string.Empty;

            foreach (var item in thingsToRemember) {
                fileContent += $"{item.Name};{item.Description};{item.DurationMin};{item.Disabled}\n";
            }

            File.WriteAllText(ReminderPath, fileContent);
        }
    }
}

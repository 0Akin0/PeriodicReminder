using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace PeriodicReminder {
    public class Reminder {
        const int MinuteInTicks = 60000;
        List<ThingToRemember> ThingsToRemember;
        Timer Timer;
        int MinutesPassed = 0;

        public Reminder(List<ThingToRemember> thingsToRemember) {
            ThingsToRemember = thingsToRemember;

            Timer = new Timer(MinuteInTicks) { AutoReset = true };
            Timer.Elapsed += TimerElapsed;
        }

        public void Start() {
            Timer.Start();
        }

        public void Stop() {
            Timer.Stop();
        }

        private void TimerElapsed(object sender, ElapsedEventArgs e) {
            string message = string.Empty;
            short ranking = 1;
            MinutesPassed += 1;

            foreach (var item in ThingsToRemember) {
                if (RemindNow(item)) {
                    message += $"{ranking}. {item.Name}\n";
                    if (!string.IsNullOrEmpty(item.Description)) {
                        message += FormatDescription(item.Description);
                    }
                    message += "\n";
                    ranking++;
                }
            }

            if (!string.IsNullOrEmpty(message)) {
                message = "Don't forget to:\n" + message;
                ReminderMessageBox(message);
            }
        }

        private bool RemindNow(ThingToRemember thing) {
            return MinutesPassed % thing.DurationMin == 0 && !thing.Disabled;
        }

        private void ReminderMessageBox(string message) {
            ReminderForm.Open(message);
        }

        private string FormatDescription(string description) {
            string formated = string.Empty;
            int maxCharsPerLine = 35;
            List<string> lines = ChunksUpto(description, maxCharsPerLine).ToList();

            foreach (var line in lines) {
                formated += $"           {line}\n";
            }

            return formated;
        }
        static IEnumerable<string> ChunksUpto(string str, int maxChunkSize) {
            for (int i = 0; i < str.Length; i += maxChunkSize)
                yield return str.Substring(i, Math.Min(maxChunkSize, str.Length - i));
        }

    }
}

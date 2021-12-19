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
                        message += $"           {item.Description}\n";
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
            return MinutesPassed % thing.DurationMin == 0;
        }

        private void ReminderMessageBox(string message) {
            ReminderForm.Open(message);
            //System.Windows.Forms.MessageBox.Show(message, "Reminder", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }

    }
}

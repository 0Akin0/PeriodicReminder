﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeriodicReminder {
    public partial class Form1 : Form {
        Reminder Reminder;
        ReminderTextFileConn Conn = new ReminderTextFileConn();

        public Form1() {
            InitializeComponent();
            lboReminders.Items.Clear();
            lboReminders.Items.AddRange(Conn.GetThingsToRemember().ToArray());
        }

        protected override void OnClosing(CancelEventArgs e) {
            var result = MessageBox.Show("Save before closing?", "Reminder", MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes) {
                Conn.SaveThingsToRemember(GetThingsToRememberFromListBox());
            } else if (result == DialogResult.Cancel) {
                e.Cancel = true;
            }
        }

        private void btnStart_Click(object sender, EventArgs e) {
            Reminder = new Reminder(GetThingsToRememberFromListBox());
            Reminder.Start();
            SwitchReminderActiveMessage(true);
        }

        private void btnStop_Click(object sender, EventArgs e) {
            Reminder.Stop();
            Reminder = null;
            SwitchReminderActiveMessage(false);
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            AddReminderForm addForm = new AddReminderForm();
            addForm.ShowDialog();
            if (addForm.NewThingToRemember != null) {
                lboReminders.Items.Add(addForm.NewThingToRemember);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e) {
            var result = MessageBox.Show("Are you sure you want to delete this?", "Reminder", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes) {
                lboReminders.Items.Remove(lboReminders.SelectedItem);
            }
        }

        private void SwitchReminderActiveMessage(bool on) {
            string status = on ? "On": "Off";
            lblRemindingStatus.Text = $"Reminding is {status}";
        }

        private List<ThingToRemember> GetThingsToRememberFromListBox() {
            List<ThingToRemember> things = new List<ThingToRemember>();

            foreach (ThingToRemember item in lboReminders.Items) {
                things.Add(item);
            }

            return things;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeriodicReminder {
    public partial class ReminderEditAddForm : Form {
        public ThingToRemember OldThingToRemember { get; set; }
        public ThingToRemember NewThingToRemember { get; set; }

        public ReminderEditAddForm() {
            InitializeComponent();
        }

        public ReminderEditAddForm(ThingToRemember old) : this() {
            OldThingToRemember = old;
        }

        private void AddReminderForm_Load(object sender, EventArgs e) {
            if (OldThingToRemember!=null) {
                txtName.Text = OldThingToRemember.Name;
                txtDescription.Text = OldThingToRemember.Description;
                txtTime.Text = OldThingToRemember.DurationMin.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            NewThingToRemember = new ThingToRemember();
            NewThingToRemember.Name = txtName.Text;
            NewThingToRemember.Description = txtDescription.Text;
            NewThingToRemember.DurationMin = int.Parse(txtTime.Text);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            Close();
        }
    }
}

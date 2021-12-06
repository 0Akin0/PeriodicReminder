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
    public partial class AddReminderForm : Form {
        public ThingToRemember NewThingToRemember { get; set; }

        public AddReminderForm() {
            InitializeComponent();
        }

        private void AddReminderForm_Load(object sender, EventArgs e) {

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

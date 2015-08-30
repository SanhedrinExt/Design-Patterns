using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FacebookIntegrationExcercise
{
    public partial class FormEventResponder : Form
    {
        private const bool v_CheckItem = true;

        /// <summary>
        /// List of selected events to RSVP.
        /// </summary>
        public FacebookObjectCollection<Event> SelectedEvents { get; private set; }
        /// <summary>
        /// The requested RSVP response.
        /// </summary>
        public Event.eRsvpType SelectedRSVPStatus { get; private set; }

        public FormEventResponder(FacebookObjectCollection<Event> i_FacebookObjectCollection)
        {
            InitializeComponent();

            initChakBoxVal(i_FacebookObjectCollection);
        }

        private void initChakBoxVal(FacebookObjectCollection<Event> i_FacebookObjectCollection)
        {
            checkedListBoxEvents.DisplayMember = "Name";

            foreach (Event fbEvent in i_FacebookObjectCollection)
            {
                if (fbEvent.StartTime != null && (DateTime.Now.CompareTo(fbEvent.StartTime) < 0))
                {
                    checkedListBoxEvents.Items.Add(fbEvent);
                    checkedListBoxEvents.SetItemChecked(checkedListBoxEvents.Items.Count - 1, true);
                }
            }

            comboBoxRSVPOptions.Items.AddRange(Enum.GetNames(typeof(Event.eRsvpType)) as string[]);

            if (checkedListBoxEvents.Items.Count == 0)
            {
                MessageBox.Show("No pending events to show.");
            }
        }

        private void buttonRespond_Click(object sender, EventArgs e)
        {
            if (comboBoxRSVPOptions.SelectedItem != null)
            {
                SelectedRSVPStatus = (Event.eRsvpType)Enum.Parse(typeof(Event.eRsvpType), comboBoxRSVPOptions.SelectedItem.ToString());

                SelectedEvents = new FacebookObjectCollection<Event>();
                foreach (object checkedEvent in checkedListBoxEvents.CheckedItems)
                {
                    SelectedEvents.Add(checkedEvent as Event);
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void buttonCheckAll_Click(object sender, EventArgs e)
        {
            setCheckedOnAll(v_CheckItem);
        }

        private void buttonUncheckAll_Click(object sender, EventArgs e)
        {
            setCheckedOnAll(!v_CheckItem);
        }

        private void setCheckedOnAll(bool i_CheckedValue)
        {
            for (int i = 0; i < checkedListBoxEvents.Items.Count; ++i)
            {
                checkedListBoxEvents.SetItemChecked(i, i_CheckedValue);
            }
        }
    }
}

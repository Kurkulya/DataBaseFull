using DataBaseApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseWF
{
    public partial class SinglePerson : Form
    {
        DataGridSingleViewFormer dgFormer;
        Person person;

        public SinglePerson(int id)
        {
            InitializeComponent();
            dgFormer = new DataGridSingleViewFormer(dataGridSingle, id);
            dgFormer.FormTable();
            dgFormer.UpdateTable();

            FillFields();
        }

        private void FillFields()
        {
            person = dgFormer.Person;
            idLabel.Text = person.Id.ToString();
            mainIdLabel.Text = person.Id.ToString();
            fnLabel.Text = person.FirstName;
            lnLabel.Text = person.LastName;
            ageLabel.Text = person.Age.ToString();

            fnTextBox.Text = person.FirstName;
            lnTextBox.Text = person.LastName;
            ageTextBox.Text = person.Age.ToString();
        }

        private void CreatePhoneButton_Click(object sender, EventArgs e)
        {
            dgFormer.AddPhone(new Phone(phoneTextBox.Text, Convert.ToInt32(idLabel.Text)));
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            dgFormer.UpdatePerson(new Person(Convert.ToInt32(idLabel.Text),fnTextBox.Text,
                lnTextBox.Text, Convert.ToInt32(ageTextBox.Text)));
            FillFields();
        }
    }
}

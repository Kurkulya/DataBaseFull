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

namespace DataBaseWF.InputForms
{
    public partial class CreatePersonForm : Form
    {
        public Person Person { get; private set; }
        public CreatePersonForm()
        {
            InitializeComponent();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            Person = new Person(Convert.ToInt32(idTextBox.Text), fnTextBox.Text,
                lnTextBox.Text, Convert.ToInt32(ageTextBox.Text));
            Close();
        }
    }
}

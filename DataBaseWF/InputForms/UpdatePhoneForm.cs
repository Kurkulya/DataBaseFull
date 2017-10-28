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
    public partial class UpdatePhoneForm : Form
    {
        public string Phone;
        public UpdatePhoneForm(string phone)
        {
            InitializeComponent();
            phoneTextBox.Text = phone;
        }

        private void updatePhone_Click(object sender, EventArgs e)
        {
            Phone = phoneTextBox.Text;
            Close();
        }
    }
}

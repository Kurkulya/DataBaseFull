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
    public partial class Form1 : Form
    {
        TablePanel tablePanel = null;
        public Form1()
        {
            InitializeComponent();
            tablePanel = new TablePanel(0);
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            tablePanel.Delete(GetPerson());
        }

        private void bUpdate_Click(object sender, EventArgs e)
        {
            tablePanel.Update(GetPerson());
        }

        private void bRead_Click(object sender, EventArgs e)
        {
            dataGrid.DataSource = tablePanel.Read();
        }

        private void bCreate_Click(object sender, EventArgs e)
        {
            tablePanel.Create(GetPerson());
        }

        private void SQLSwitcher_SelectedIndexChanged(object sender, EventArgs e)
        {
            tablePanel = new TablePanel(SQLSwitcher.SelectedIndex);
            tablePanel.ClearTable(dataGrid);
        }

        private Person GetPerson()
        {
            int id = Int32.Parse(boxId.Text);
            string fn = boxFirstName.Text;
            string ln = boxLastName.Text;
            int age = Int32.Parse(boxAge.Text);
            return new Person(id, fn, ln, age);
        }
    }
}

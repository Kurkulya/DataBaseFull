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
        DataGridViewFormer dgFormer;
        PersonDAO dao;
        public Form1()
        {
            InitializeComponent();
            dgFormer = new DataGridViewFormer(dataGridMany);
            dgFormer.FormTable();

            databaseComboBox.Items.Add("MOCK");           
            dao = new PersonDAO("MOCK");
            databaseComboBox.SelectedIndex = 0;
            //dataGridMany.DataSource = dao.Read();
            dgFormer.AddRows(dao.Read());
        }

        private void DatabaseSelected(object sender, EventArgs e)
        {
            dao.SetDataBase(databaseComboBox.SelectedItem.ToString());
        }
    }
}

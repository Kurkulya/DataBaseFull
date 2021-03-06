﻿using DataBaseApi;
using DataBaseWF.InputForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DataBaseWF.DataGridManyViewFormer;

namespace DataBaseWF
{
    public partial class ManyPersons : Form
    {
        DataGridManyViewFormer dgFormer;
        public ManyPersons()
        {
            InitializeComponent();
            dgFormer = new DataGridManyViewFormer(dataGridMany);
            dgFormer.FormTable();
            dgFormer.UpdateTable();

            string[] databases = { "MOCK", "MS SQL", "BIN_L", "CSV_L", "JSON_L", "XML_L", "YAML_L", "JSON",
            "H2", "MY SQL", "MONGODB", "CSV", "XML", "YAML", "MS SQL EF"};
            foreach(string db in databases)
            {
                databaseComboBox.Items.Add(db);
            }
            databaseComboBox.SelectedIndex = 0;
            searchComboBox.SelectedIndex = 0;
            
        }

        private void DatabaseSelected(object sender, EventArgs e)
        {
            DataGridManyViewFormer.Dao.SetDataBase(databaseComboBox.SelectedItem.ToString());
            dgFormer.UpdateTable();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            CreatePersonForm cpForm = new CreatePersonForm();
            cpForm.ShowDialog();
            if (cpForm.Person != null)
                dgFormer.CreatePerson(cpForm.Person);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            SearchBy criteria = SearchBy.ByFirstName;
            switch(searchComboBox.SelectedItem.ToString())
            {
                case "By Id": criteria = SearchBy.ById; break;
                case "By First Name": criteria = SearchBy.ByFirstName; break;
                case "By Last Name": criteria = SearchBy.ByLastName; break;
                case "By Age": criteria = SearchBy.ByAge; break;
            }
            dgFormer.SearchPersons(criteria, searchTextBox.Text);
        }
    }
}

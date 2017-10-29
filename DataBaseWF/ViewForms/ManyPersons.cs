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

            string[] databases = { "MOCK", "MS SQL", "BIN_L", "CSV_L", "JSON_L", "XML_L", "YAML_L", "JSON" };
            foreach(string db in databases)
            {
                databaseComboBox.Items.Add(db);
            }
                     
            databaseComboBox.SelectedIndex = 0;

            
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
    }
}

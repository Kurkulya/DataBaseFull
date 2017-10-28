using DataBaseApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseWF
{
    class DataGridViewFormer
    {
        DataGridView dataGrid;
        string deleteColumnText = "X";
        string editColumnText = "->";

        enum Width {Small = 35, Medium = 60, Large = 100 }

        public DataGridViewFormer(DataGridView dataGrid)
        {
            this.dataGrid = dataGrid;
            dataGrid.AllowUserToAddRows = false;
            dataGrid.CellClick += CellClick;
        }

        private void CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0)
            {
                if (dataGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
                {
                    DataGridViewButtonColumn buttonCell = dataGrid.Columns[e.ColumnIndex] as DataGridViewButtonColumn;
                    if (buttonCell.Text == deleteColumnText)
                        MessageBox.Show("Delete");
                    else if (buttonCell.Text == editColumnText)
                        MessageBox.Show("Edit");
                }
            }
        }

        public void FormTable()
        {
            AddTextColumn("id", "Id", Width.Small);
            AddTextColumn("fn", "First Name", Width.Large);
            AddTextColumn("ln", "Last Name", Width.Large);
            AddTextColumn("age", "Age", Width.Small);
            AddButtonColumn(editColumnText, Width.Small);
            AddButtonColumn(deleteColumnText, Width.Small);       
        }


        private void AddTextColumn(string name, string text, Width width)
        {
            DataGridViewColumn column = new DataGridViewColumn();
            column.Name = name;
            column.Width = (int)width;
            column.HeaderText = text;
            column.CellTemplate = new DataGridViewTextBoxCell();
            dataGrid.Columns.Add(column);
        }

        private void AddButtonColumn(string text, Width width)
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();       
            btn.Width = (int)width;
            btn.Text = text;
            btn.UseColumnTextForButtonValue = true;
            dataGrid.Columns.Add(btn);
        }

        public void AddRows(List<Person> people)
        {
            foreach (Person person in people)
            {
                dataGrid.Rows.Add(person.Id, person.FirstName, person.LastName, person.Age);
            }
        }
    }
}

using DataBaseApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseWF
{
    class DataGridManyViewFormer : DataGridViewFormer
    {
        DataGridView dataGrid;
        string deleteColumnText = "X";
        string editColumnText = "->";

        public enum SearchBy {ById, ByFirstName, ByLastName, ByAge }

        public DataGridManyViewFormer(DataGridView dataGrid) : base(dataGrid)
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
                    DataGridViewRow row = dataGrid.Rows[e.RowIndex];
                    if (buttonCell.Text == deleteColumnText)
                    {
                        Dao.Delete(new Person((int)row.Cells["id"].Value, (string)row.Cells["fn"].Value,
                            (string)row.Cells["ln"].Value, (int)row.Cells["age"].Value));
                        UpdateTable();
                    }
                    else if (buttonCell.Text == editColumnText)
                    {                       
                        SinglePerson singleForm = new SinglePerson((int)row.Cells["id"].Value);
                        singleForm.ShowDialog();
                        UpdateTable();
                    }
                }
            }
        }

        internal void CreatePerson(Person person)
        {
            Dao.Create(person);
            UpdateTable();
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

        public void SearchPersons(SearchBy criteria, string text)
        {
            List<Person> people = Dao.Read();
            List<Person> find = null;

            if(criteria == SearchBy.ById)
                find = people.Where(x => x.Id.ToString().Contains(text)).ToList();
            else if(criteria == SearchBy.ByFirstName)
                find = people.Where(x => x.FirstName.Contains(text)).ToList();
            else if (criteria == SearchBy.ByLastName)
                find = people.Where(x => x.LastName.Contains(text)).ToList();
            else if (criteria == SearchBy.ByAge)
                find = people.Where(x => x.Age.ToString().Contains(text)).ToList();

            dataGrid.Rows.Clear();
            foreach (Person person in find)
            {
                dataGrid.Rows.Add(person.Id, person.FirstName, person.LastName, person.Age);
            }
        }

        public void UpdateTable()
        {
            List<Person> people = Dao.Read();
            dataGrid.Rows.Clear();
            foreach (Person person in people)
            {
                dataGrid.Rows.Add(person.Id, person.FirstName, person.LastName, person.Age);
            }
        }


    }
}

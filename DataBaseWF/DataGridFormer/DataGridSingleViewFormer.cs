using DataBaseApi;
using DataBaseWF.InputForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseWF
{
    class DataGridSingleViewFormer : DataGridViewFormer
    {
        DataGridView dataGrid;
        string deleteColumnText = "X";
        string editColumnText = "->";
        public Person Person { get; private set; }

        public DataGridSingleViewFormer(DataGridView dataGrid, int id) : base(dataGrid)
        {
            this.dataGrid = dataGrid;
            Person = Dao.ReadPerson(id);
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
                        Dao.DeletePhone(Person, Person.Phones[e.RowIndex]);
                        UpdateTable();
                    }
                    else if (buttonCell.Text == editColumnText)
                    {
                        UpdatePhoneForm updForm = new UpdatePhoneForm(Person.Phones[e.RowIndex].Number);
                        updForm.ShowDialog();
                        Person.Phones[e.RowIndex].Number = updForm.Phone;
                        Dao.UpdatePhone(Person, Person.Phones[e.RowIndex]);
                        UpdateTable();
                    }
                }
            }
        }

        internal void UpdatePerson(Person person)
        {
            Dao.Update(person);
            Person = Dao.ReadPerson(person.Id);
        }

        internal void AddPhone(Phone phone)
        {
            Dao.AddPhone(Person, phone);
            UpdateTable();
        }

        public void FormTable()
        {
            AddTextColumn("phone", "Phone", Width.Large);
            AddButtonColumn(editColumnText, Width.Small);
            AddButtonColumn(deleteColumnText, Width.Small);       
        }

        public void UpdateTable()
        {
            Person = Dao.ReadPerson(Person.Id);
            List<Phone> phones = Dao.ReadPerson(Person.Id).Phones;

            if (phones == null)
                return;

            dataGrid.Rows.Clear();
            foreach (Phone phone in phones)
            {
                dataGrid.Rows.Add(phone.Number);
            }
        }
    }
}

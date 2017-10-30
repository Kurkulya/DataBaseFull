using DataBaseApi;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBaseWF
{
    class DataGridViewFormer
    {
        DataGridView dataGrid;
        protected enum Width {Small = 35, Medium = 60, Large = 100 }
        public static PersonDAO Dao = new PersonDAO("MOCK");

        public DataGridViewFormer(DataGridView dataGrid)
        {
            this.dataGrid = dataGrid;
        }

        protected void AddTextColumn(string name, string text, Width width)
        {
            DataGridViewColumn column = new DataGridViewColumn();
            column.Name = name;
            column.Width = (int)width;
            column.HeaderText = text;
            column.DefaultCellStyle.Font = new Font("Times New Roman", 8);
            column.CellTemplate = new DataGridViewTextBoxCell();
            dataGrid.Columns.Add(column);
        }

        protected void AddButtonColumn(string text, Width width)
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();       
            btn.Width = (int)width;
            btn.Text = text;
            btn.DefaultCellStyle.Font = new Font("Times New Roman", 8);
            btn.UseColumnTextForButtonValue = true;
            dataGrid.Columns.Add(btn);
        }    
    }
}

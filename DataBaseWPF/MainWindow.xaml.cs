using DataBaseApi;
using System;
using System.Windows;
using System.Windows.Controls;


namespace DataBaseWPF
{
    public partial class MainWindow : Window
    {
        TablePanel tablePanel = null;
        public MainWindow()
        {
            InitializeComponent();
            tablePanel = new TablePanel(0);
        }

        private void bCreate_Click(object sender, RoutedEventArgs e)
        {
            tablePanel.Create(GetPerson());
        }

        private void bRead_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = tablePanel.Read();
        }

        private void bUpdate_Click(object sender, RoutedEventArgs e)
        {
            tablePanel.Update(GetPerson());
        }

        private void bDelete_Click(object sender, RoutedEventArgs e)
        {
            tablePanel.Delete(GetPerson());
        }

        private void SelectDB(object sender, SelectionChangedEventArgs e)
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

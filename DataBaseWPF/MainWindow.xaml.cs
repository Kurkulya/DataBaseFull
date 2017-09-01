using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataBaseWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
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
            tablePanel.Create(new Person(Int32.Parse(boxId.Text), boxFirstName.Text, boxLastName.Text, Int32.Parse(boxAge.Text)));
        }

        private void bRead_Click(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = tablePanel.Read();
        }

        private void bUpdate_Click(object sender, RoutedEventArgs e)
        {
            tablePanel.Update(new Person(Int32.Parse(boxId.Text), boxFirstName.Text, boxLastName.Text, Int32.Parse(boxAge.Text)));
        }

        private void bDelete_Click(object sender, RoutedEventArgs e)
        {
            tablePanel.Delete(new Person(Int32.Parse(boxId.Text), boxFirstName.Text, boxLastName.Text, Int32.Parse(boxAge.Text)));
        }

        private void SelectDB(object sender, SelectionChangedEventArgs e)
        {
            tablePanel = new TablePanel(SQLSwitcher.SelectedIndex);
            tablePanel.ClearTable(dataGrid);
        }
    }
}

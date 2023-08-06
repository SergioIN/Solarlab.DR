using Solarlab.DR.Models;
using Solarlab.DR.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Solarlab.DR
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string PATH = $"{Environment.CurrentDirectory}\\dataDr.json";
        private BindingList<Models1> _dataDr;
        private FileIOService _fileIOService;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void DatesDR_Loaded(object sender, RoutedEventArgs e)
        {
            _fileIOService = new FileIOService(PATH);
            try
            {
                _dataDr = _fileIOService.LoadData();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                Close();
            }

            datesBirthdays.ItemsSource = _dataDr;
            _dataDr.ListChanged += _dataDr_ListChanged;
        }

        private void _dataDr_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged )
            {
                try
                {
                    _fileIOService.SaveData(sender);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    Close();
                }
            }
            
        }

        private void datesBirthdays_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

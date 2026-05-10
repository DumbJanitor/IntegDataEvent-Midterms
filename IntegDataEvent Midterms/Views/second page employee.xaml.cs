using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace IntegDataEvent_Midterms.Views
{
    /// <summary>
    /// Interaction logic for second_page.xaml
    /// </summary>
    public partial class second_page : Window
    {
        public second_page()
        {
            InitializeComponent();
            DataContext = new ViewModel.second_page_employee_ViewModel();
        }
    }
}

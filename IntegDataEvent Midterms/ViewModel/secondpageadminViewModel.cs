using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace IntegDataEvent_Midterms.ViewModel
{
    class secondpageadminViewModel
    {
        public ICommand LogoutCommand { get; set; }

        public secondpageadminViewModel()
        {
            LogoutCommand = new RelayCommand(Logout);
        }

        public void Logout(object? par)
        {
            MessageBox.Show("kaboom");
            var logout = new MainWindow();
            Application.Current.Windows
            .OfType<Window>()
            .SingleOrDefault(w => w.IsActive)
            ?.Close();
            logout.Show();

        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace IntegDataEvent_Midterms.ViewModel
{
    class secondpagemanagerViewModel
    {
        public ICommand LogoutCommand { get; set; }

        public secondpagemanagerViewModel()
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

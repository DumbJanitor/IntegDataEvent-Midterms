using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using Microsoft.Data.SqlClient;
using IntegDataEvent_Midterms.Views;

namespace IntegDataEvent_Midterms.ViewModel
{
    class LoginViewModel : ObservableObject
    {
        public Model.UserModel currentUser { get; set; }

        public ICommand logincommand { get; set; }

        public LoginViewModel()
        {
            currentUser = new Model.UserModel();
            logincommand = new RelayCommand(ExecuteLogin);
        }

        private void ExecuteLogin(object? parameter)
        {

            // Grab the password from the UI
            var passwordBox = parameter as System.Windows.Controls.PasswordBox;
            if (passwordBox != null)
            {
                currentUser.Password = passwordBox.Password;
            }

            // Define the connection string (Windows Auth)

            string connectionString = @"Server=ANDREI-LP;Database=IntegDataEvent;Trusted_Connection=True;TrustServerCertificate=True;";

            bool isLoginValid = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // The Secure Way — Parameterized Query
                    string query = "SELECT * FROM Users WHERE Email = @username AND Password = @password";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", currentUser.Username);
                        command.Parameters.AddWithValue("@password", currentUser.Password);
                        // ... execute as normal ...
                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            string position = "";
                            if (reader.Read())
                            {
                                position = reader.GetString(reader.GetOrdinal("Position"));
                            }

                            if (reader.HasRows)
                            {
                                switch (position)
                                {
                                    case "Admin":
                                        isLoginValid = true;
                                        var second_page_admin = new second_page_admin();
                                        second_page_admin.Show();
                                        Application.Current.MainWindow.Close();
                                        break;

                                    case "Employee":
                                        isLoginValid = true;
                                        var second_page_employee = new second_page();
                                        second_page_employee.Show();
                                        Application.Current.MainWindow.Close();
                                        break;

                                    default:
                                        MessageBox.Show("Position doesnt exist");
                                        break;
                                } 
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database connection failed: " + ex.Message);
                return;
            }

            if (isLoginValid)
            {
                //MessageBox.Show("Login Successful! Welcome.", "Success",
                //    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                currentUser.Password = string.Empty;
                currentUser.Username = string.Empty;
                MessageBox.Show("Invalid Username or Password.", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

using MeatProcessingBelov.ViewModels;
using MeatProcessingBelov.Views;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace MeatProcessingBelov
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = MainWindowViewModel.Instance;
            MainWindowViewModel.Instance.ShowLoginViewCommand.Execute(null);
        }

        public async Task Login(string username, string password)
        {
            MainWindowViewModel viewModel = DataContext as MainWindowViewModel;
            if (viewModel == null) return;

            viewModel.Username = username;
            viewModel.Password = password;

            try
            {
                var context = DbContextFactory.GetDbContext(username, password);
                var canConnect = await context.Database.CanConnectAsync();

                if (canConnect)
                {
                    var dbHelper = new DbHelper();
                    var userNameParam = new Microsoft.Data.SqlClient.SqlParameter("@UserName", username);
                    var roleCountParam = new Microsoft.Data.SqlClient.SqlParameter
                    {
                        ParameterName = "@RoleCount",
                        SqlDbType = System.Data.SqlDbType.Int,
                        Direction = System.Data.ParameterDirection.Output
                    };

                    // Execute the stored procedure
                    await context.Database.ExecuteSqlRawAsync("EXEC CheckUserRoles @UserName, @RoleCount OUTPUT", userNameParam, roleCountParam);

                    // Extract the output parameter value
                    var roleCount = Convert.ToInt32(roleCountParam.Value);

                    // Log role count
                    System.Diagnostics.Debug.WriteLine($"Role Count: {roleCount}");
                    System.Diagnostics.Debug.WriteLine($"Loaded: {MainContentControl.Content}");

                    LoadControlForRole(roleCount);
                }
                else
                {
                    // Handle invalid login
                    System.Windows.MessageBox.Show("Invalid username or password", "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
                System.Windows.MessageBox.Show("An error occurred: " + ex.Message, "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadControlForRole(int role)
        {
            switch (role)
            {
                case 1:
                    MainWindowViewModel.Instance.ShowWorkerViewCommand.Execute(null);
                    System.Diagnostics.Debug.WriteLine($"Loaded 1: {MainContentControl.Content}");
                    break;
                case 2:
                    MainWindowViewModel.Instance.ShowManagerViewCommand.Execute(null);
                    System.Diagnostics.Debug.WriteLine($"Loaded 2: {MainContentControl.Content}");
                    break;
                case 3:
                    MainWindowViewModel.Instance.ShowAdminViewCommand.Execute(null);
                    System.Diagnostics.Debug.WriteLine($"Loaded 3: {MainContentControl.Content}");
                    break;
                default:
                    throw new InvalidOperationException("Unknown role");
            }
            System.Diagnostics.Debug.WriteLine($"Loaded In End: {MainContentControl.Content}");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
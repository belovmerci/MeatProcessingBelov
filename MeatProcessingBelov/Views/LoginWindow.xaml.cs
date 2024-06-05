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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MeatProcessingBelov.ViewModels;

namespace MeatProcessingBelov.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : UserControl
    {
        public LoginWindow()
        {
            InitializeComponent();
            MainWindowViewModel.WindowTitle = "Login Window";
            DataContext = MainWindowViewModel.Instance;
        }

        public void ShowErrorMessage(string message)
        {
            ErrorMessageTextBlock.Text = message;
            ErrorMessageTextBlock.Visibility = Visibility.Visible;
        }

        public void ClearFields()
        {
            UsernameTextBox.Clear();
            UserPasswordBox.Clear();
            ErrorMessageTextBlock.Visibility = Visibility.Collapsed;
        }

        public string[] GetCredentials()
        {
            return new string[] { UsernameTextBox.Text, UserPasswordBox.Password };
        }
    }
}
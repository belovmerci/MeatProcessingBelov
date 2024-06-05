using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MeatProcessingBelov.Models;
using MeatProcessingBelov.ViewModels;
using MeatProcessingBelov.Views;
using Microsoft.EntityFrameworkCore;

namespace MeatProcessingBelov.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        private static MainWindowViewModel _instance;
        public static MainWindowViewModel Instance => _instance ??= new MainWindowViewModel();

        public MainWindowViewModel()
        {
            ShowLoginViewCommand = new RelayCommand(param => ShowLoginView());
            ShowWorkerViewCommand = new RelayCommand(param => ShowWorkerView());
            ShowManagerViewCommand = new RelayCommand(param => ShowManagerView());
            ShowAdminViewCommand = new RelayCommand(param => ShowAdminView());
            LoginButtonCommand = new RelayCommand(param => LoginButton_Click());
        }

        public RelayCommand ShowLoginViewCommand { get; private set; }
        public RelayCommand ShowWorkerViewCommand { get; private set; }
        public RelayCommand ShowManagerViewCommand { get; private set; }
        public RelayCommand ShowAdminViewCommand { get; private set; }
        public RelayCommand LoginButtonCommand { get; private set; }

        public static BelovMeat2207sb1Context Context { get; set; }

        // could be in here somewhere?
        private UserControl _currentControl;
        public UserControl CurrentControl
        {
            get => _currentControl;
            set
            {
                _currentControl = value;
                System.Diagnostics.Debug.WriteLine($"CurrentControl set to: {_currentControl.GetType().Name}");
                OnPropertyChanged(nameof(CurrentControl));
            }
        }

        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private static string _windowTitle = "Belov2207sb1 Meat Processing";
        public static string WindowTitle
        {
            get
            {
                return _windowTitle;
            }
            set
            {
                _windowTitle = value;
            }
        }

        private void ShowLoginView()
        {
            CurrentControl = new LoginWindow();
        }

        private void ShowWorkerView()
        {
            CurrentControl = new WorkerControl();
        }

        private void ShowManagerView()
        {
            // comes in
            CurrentControl = new ManagerControl();
            // current control changes
        }

        private void ShowAdminView()
        {
            CurrentControl = new AdminControl();
        }


        private async void LoginButton_Click()
        {
            if (CurrentControl is LoginWindow loginWindow)
            {
                var mainWindow = Application.Current.MainWindow as MainWindow;
                await mainWindow.Login(loginWindow.UsernameTextBox.Text, loginWindow.UserPasswordBox.Password);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("CurrentControl is not of type LoginWindow");
            }
        }
    }
}
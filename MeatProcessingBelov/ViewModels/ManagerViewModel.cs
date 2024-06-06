using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MeatProcessingBelov.Models;
using MeatProcessingBelov.ViewModels;

namespace MeatProcessingBelov.ViewModels
{
    public class ManagerViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<dynamic> _preMadeQueryResults;
        private ObservableCollection<string> _tableNames;
        private ObservableCollection<dynamic> _tableData;
        private string _selectedTable;

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<dynamic> PreMadeQueryResults
        {
            get => _preMadeQueryResults;
            set
            {
                _preMadeQueryResults = value;
                OnPropertyChanged(nameof(PreMadeQueryResults));
            }
        }

        public ObservableCollection<string> TableNames
        {
            get => _tableNames;
            set
            {
                _tableNames = value;
                OnPropertyChanged(nameof(TableNames));
            }
        }

        public ObservableCollection<dynamic> TableData
        {
            get => _tableData;
            set
            {
                _tableData = value;
                OnPropertyChanged(nameof(TableData));
            }
        }

        public string SelectedTable
        {
            get => _selectedTable;
            set
            {
                _selectedTable = value;
                OnPropertyChanged(nameof(SelectedTable));
                if (!string.IsNullOrEmpty(_selectedTable))
                {
                    LoadTableDataAsync(_selectedTable);
                }
            }
        }

        public ICommand LoadPreMadeQueriesCommand { get; }

        public ManagerViewModel()
        {
            LoadPreMadeQueriesCommand = new RelayCommand(async _ => await LoadPreMadeQueriesAsync());
            LoadTableNamesAsync();
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async Task LoadPreMadeQueriesAsync()
        {
            var context = DbContextFactory.GetExistingDbContext();

            // Example query for pre-made queries
            PreMadeQueryResults = new ObservableCollection<dynamic>(
                await context.Работникиs
                    .Select(w => new { w.Имя })
                    .ToListAsync()
            );
        }

        private async Task LoadTableNamesAsync()
        {
            var context = DbContextFactory.GetExistingDbContext();
            var tempTableNames = context.GetType().GetProperties()
                .Where(p => p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
                .Select(p => p.Name).ToList();
            // Retrieve all table names in the database
            TableNames = new ObservableCollection<string>();
            foreach (var table in tempTableNames) TableNames.Add(table);
        }

        private async Task LoadTableDataAsync(string tableName)
        {
            var context = DbContextFactory.GetExistingDbContext();

            // Retrieve all data from the selected table
            TableData = new ObservableCollection<dynamic>(
                await context.Database
                    .SqlQuery<dynamic>($"SELECT * FROM {tableName}")
                    .ToListAsync()
            );
        }
    }
}
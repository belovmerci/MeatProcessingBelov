using MeatProcessingBelov.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Controls;
using MeatProcessingBelov.ViewModels;

namespace MeatProcessingBelov.Views
{
    public partial class AdminControl : UserControl, INotifyPropertyChanged
    {
        private ObservableCollection<FieldEntry> _entryFields;
        private ObservableCollection<string> _tableNames;
        private ObservableCollection<dynamic> _tableData;
        private string _selectedTable;

        public AdminControl()
        {
            InitializeComponent();
            DataContext = this;

            // Initialize collections
            EntryFields = new ObservableCollection<FieldEntry>();
            TableNames = new ObservableCollection<string>();
            TableData = new ObservableCollection<dynamic>();

            // Load table names from database
            LoadTableNames();

            AddEntryCommand = new RelayCommand(async param => await AddEntry());
        }

        public ObservableCollection<FieldEntry> EntryFields
        {
            get { return _entryFields; }
            set
            {
                _entryFields = value;
                OnPropertyChanged(nameof(EntryFields));
            }
        }

        public ObservableCollection<string> TableNames
        {
            get { return _tableNames; }
            set
            {
                _tableNames = value;
                OnPropertyChanged(nameof(TableNames));
            }
        }

        public ObservableCollection<dynamic> TableData
        {
            get { return _tableData; }
            set
            {
                _tableData = value;
                OnPropertyChanged(nameof(TableData));
            }
        }

        public string SelectedTable
        {
            get { return _selectedTable; }
            set
            {
                _selectedTable = value;
                OnPropertyChanged(nameof(SelectedTable));
                if (!string.IsNullOrEmpty(_selectedTable))
                {
                    LoadTableColumns();
                    LoadTableData();
                }
            }
        }

        public RelayCommand AddEntryCommand { get; private set; }

        private void LoadTableNames()
        {
            var context = DbContextFactory.GetExistingDbContext();
            var tableNames = context.Model.GetEntityTypes()
                .Select(t => t.GetTableName())
                .Distinct()
                .ToList();
            TableNames.Clear();
            foreach (var tableName in tableNames)
            {
                TableNames.Add(tableName);
            }
        }
        /*
        private async Task LoadTableNames()
        {
            var context = DbContextFactory.GetExistingDbContext();
            var tempTableNames = context.GetType().GetProperties()
                .Where(p => p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>))
                .Select(p => p.Name).ToList();
            // Retrieve all table names in the database
            TableNames = new ObservableCollection<string>();
            foreach (var table in tempTableNames) TableNames.Add(table);
        }
        */


        private void LoadTableColumns()
        {
            EntryFields.Clear();

            if (string.IsNullOrEmpty(SelectedTable))
                return;

            var context = DbContextFactory.GetExistingDbContext();
                var entityType = context.Model.FindEntityType($"MeatProcessingBelov.Models.{SelectedTable}");
                if (entityType == null)
                {
                    throw new InvalidOperationException($"The table {SelectedTable} does not exist in the context.");
                }

                var columns = entityType.GetProperties()
                    .Select(p => p.Name)
                    .ToList();

                foreach (var column in columns)
                {
                    if (!column.Equals("ID", StringComparison.OrdinalIgnoreCase))
                    {
                        EntryFields.Add(new FieldEntry { FieldName = column });
                    }
                }
        }

        private async Task LoadTableData()
        {
            var context = DbContextFactory.GetExistingDbContext();
                var sql = $"SELECT * FROM {SelectedTable}";
                var data = await context.Set<dynamic>()
                    .FromSqlRaw(sql)
                    .ToListAsync();

                TableData.Clear();
                foreach (var item in data)
                {
                    TableData.Add(item);
                }
        }

        private async Task AddEntry()
        {
            var context = DbContextFactory.GetExistingDbContext();
                var newEntry = new Dictionary<string, object>();
                foreach (var field in EntryFields)
                {
                    newEntry.Add(field.FieldName, field.FieldValue);
                }

                var columnNames = string.Join(", ", newEntry.Keys);
                var parameterNames = string.Join(", ", newEntry.Keys.Select(k => $"@{k}"));
                var sql = $"INSERT INTO {SelectedTable} ({columnNames}) VALUES ({parameterNames})";

                var parameters = newEntry.Select(kvp => new SqlParameter($"@{kvp.Key}", kvp.Value ?? DBNull.Value)).ToArray();
                await context.Database.ExecuteSqlRawAsync(sql, parameters);

            foreach (var field in EntryFields)
            {
                field.FieldValue = string.Empty;
            }

            LoadTableData();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class FieldEntry : INotifyPropertyChanged
    {
        private string _fieldName;
        private string _fieldValue;

        public string FieldName
        {
            get { return _fieldName; }
            set
            {
                _fieldName = value;
                OnPropertyChanged(nameof(FieldName));
            }
        }

        public string FieldValue
        {
            get { return _fieldValue; }
            set
            {
                _fieldValue = value;
                OnPropertyChanged(nameof(FieldValue));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

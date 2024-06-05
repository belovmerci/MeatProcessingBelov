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

namespace MeatProcessingBelov.ViewModels
{
    public class WorkerViewModel : INotifyPropertyChanged
    {
        private readonly DbHelper _dbHelper;
        private ObservableCollection<object> _tableData;
        private string _selectedTable;
        private List<string> _tableNames;

        public WorkerViewModel()
        {
            _dbHelper = new DbHelper();
            LoadTableNames();
        }

        public List<string> TableNames
        {
            get { return _tableNames; }
            set
            {
                _tableNames = value;
                OnPropertyChanged();
            }
        }

        public string SelectedTable
        {
            get { return _selectedTable; }
            set
            {
                if (_selectedTable != value)
                {
                    _selectedTable = value;
                    OnPropertyChanged();
                    LoadTableData();  // Load data when a table is selected
                }
            }
        }

        public ObservableCollection<object> TableData
        {
            get { return _tableData; }
            set
            {
                _tableData = value;
                OnPropertyChanged();
            }
        }

        private async void LoadTableNames()
        {
            TableNames = await _dbHelper.GetTableNames();
        }

        private async void LoadTableData()
        {
            if (string.IsNullOrEmpty(SelectedTable))
                return;

            var data = await _dbHelper.GetTableData(SelectedTable);
            TableData = new ObservableCollection<object>(data);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
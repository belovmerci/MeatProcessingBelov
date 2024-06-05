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
using MeatProcessingBelov.Models;
using MeatProcessingBelov.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace MeatProcessingBelov.Views
{
    /// <summary>
    /// Interaction logic for ManagerControl.xaml
    /// </summary>
    public partial class ManagerControl : UserControl
    {
        private ManagerViewModel _viewModel;

        public ManagerControl()
        {
            InitializeComponent();
            _viewModel = new ManagerViewModel();
            MainWindowViewModel.WindowTitle = "Manager Window";
            DataContext = _viewModel;

            _viewModel.PropertyChanged += ViewModel_PropertyChanged;
        }

        private void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_viewModel.TableData))
            {
                GenerateColumns();
            }
        }

        private void GenerateColumns()
        {
            if (_viewModel.TableData == null || _viewModel.TableData.Count == 0)
                return;

            var gridView = (GridView)TableListView.View;
            gridView.Columns.Clear();

            var firstItem = _viewModel.TableData.FirstOrDefault();
            if (firstItem != null)
            {
                var properties = firstItem.GetType().GetProperties();
                foreach (var property in properties)
                {
                    gridView.Columns.Add(new GridViewColumn
                    {
                        Header = property.Name,
                        DisplayMemberBinding = new System.Windows.Data.Binding(property.Name)
                    });
                }
            }
        }
    }
}
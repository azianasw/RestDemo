using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using WpfApp.Commands;

namespace WpfApp.ViewModels
{
    public class EmployeeListingViewModel : ViewModelBase
    {
        private List<EmployeeViewModel> _employee;
        public List<EmployeeViewModel> Employees
        {
            get => _employee;
            set
            {
                _employee = value;
                OnPropertyChanged(nameof(Employees));
            }
        }
        private EmployeeViewModel _selected;
        public EmployeeViewModel Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;
            }
        }
        public ICommand RefreshCommand { get; }
        public ICommand AddCommand { get; }
        public ICommand UpdateCommand { get; }
        public ICommand DeleteCommand { get; }
        public SnackbarMessageQueue MessageQueue { get; set; }

        public EmployeeListingViewModel()
        {
            RefreshCommand = new RefreshEmployeeListingCommand(this);
            UpdateCommand = new UpdateEmployeeListingCommand(this);
            DeleteCommand = new DeleteEmployeeListingCommand(this);

            MessageQueue = new SnackbarMessageQueue();
        }
    }
}

using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WpfApp.Commands;

namespace WpfApp.ViewModels
{
    public class AddEmployeeViewModel : ViewModelBase
    {
        private string _fullname;
        public string Fullname
        {
            get => _fullname;
            set
            {
                _fullname = value;
                OnPropertyChanged(nameof(Fullname));
            }
        }
        private string _address;
        public string Address
        {
            get => _address;
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }
        private string _position;
        public string Position
        {
            get => _position;
            set
            {
                _position = value;
                OnPropertyChanged(nameof(Position));
            }
        }
        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }
        public SnackbarMessageQueue MessageQueue { get; set; }

        public AddEmployeeViewModel(Store.NavigationStore navigationStore, Func<EmployeeListingViewModel> createEmployeeListingViewModel)
        {
            SubmitCommand = new AddEmployeeCommand(this);
            CancelCommand = new NavigateCommand(navigationStore, createEmployeeListingViewModel);

            MessageQueue = new SnackbarMessageQueue();
        }

        public AddEmployeeViewModel()
        {
            SubmitCommand = new AddEmployeeCommand(this);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using WpfApp.Commands;

namespace WpfApp.ViewModels
{
    public class UpdateEmployeeViewModel : ViewModelBase
    {
        private readonly Employee _employee;

        public long Id
        {
            get => _employee.Id;
            set => _employee.Id = value;
        }
        public string Fullname
        {
            get => _employee.Fullname;
            set => _employee.Fullname = value;
        }
        public string Address
        {
            get => _employee.Address;
            set => _employee.Address = value;
        }
        public string Position
        {
            get => _employee.Position;
            set => _employee.Position = value;
        }

        public ICommand SaveCommand { get; }

        public UpdateEmployeeViewModel(Employee employee)
        {
            _employee = employee;

            SaveCommand = new SaveUpdateEmployeeCommand(this);
        }

    }
}

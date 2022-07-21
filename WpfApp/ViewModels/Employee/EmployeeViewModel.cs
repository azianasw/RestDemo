using System;
using System.Collections.Generic;
using System.Text;
using WpfApp.Models;

namespace WpfApp.ViewModels
{
    public class EmployeeViewModel : ViewModelBase
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

        public EmployeeViewModel(Employee employee)
        {
            _employee = employee;
        }
    }
}

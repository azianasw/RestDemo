using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WpfApp.ViewModels;

namespace WpfApp.Commands
{
    public class AddEmployeeCommand : CommandBase
    {
        private readonly AddEmployeeViewModel _addEmployeeViewModel;

        public AddEmployeeCommand(AddEmployeeViewModel addEmployeeViewModel)
        {
            _addEmployeeViewModel = addEmployeeViewModel;
        }

        public override void Execute(object parameter)
        {
            var newEmployee = new Employee()
            {
                Fullname = _addEmployeeViewModel.Fullname,
                Address = _addEmployeeViewModel.Address,
                Position = _addEmployeeViewModel.Position
            };

            var resp = WebApi.Post("employees", newEmployee);

            if (resp.Result.StatusCode == System.Net.HttpStatusCode.Created)
            {
                _addEmployeeViewModel.MessageQueue.Enqueue($"{newEmployee.Fullname}'s details has successfully been added!");
            }
        }
    }
}

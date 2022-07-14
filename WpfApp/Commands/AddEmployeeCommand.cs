using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                Employee newEmployee = new Employee()
                {
                    Fullname = _addEmployeeViewModel.Fullname,
                    Address = _addEmployeeViewModel.Address,
                    Position = _addEmployeeViewModel.Position
                };

                HttpResponseMessage resp = await WebApi.PostAsync("employees", newEmployee);

                if (resp.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    _ = MessageBox.Show("Data berhasil ditambahkan", "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception)
            {
            }
        }
    }
}

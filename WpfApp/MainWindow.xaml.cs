using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json;
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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public string Url { get; set; } = "employees";

        public long Id { get; set; }
        public string Fullname { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }

        private List<Employee> employees;
        public List<Employee> Employees
        {
            get => employees;
            set
            {
                employees = value;
                NotifyPropertyChanged("Employees");

            }
        }

        public Employee Selected { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var newEmployee = new Employee()
            {
                Fullname = Fullname,
                Address = Address,
                Position = Position
            };

            var created = WebApi.Post<Employee>(Url, newEmployee);
            if (created.Result.StatusCode == System.Net.HttpStatusCode.Created)
            {
                MessageBox.Show($"{newEmployee.Fullname}'s details has successfully been added!");
            }
            else
            {
                MessageBox.Show($"Failed to update {newEmployee.Fullname}'s details.");
            }
        }

        private void ButtonGet_Click(object sender, RoutedEventArgs e)
        {
            var response = WebApi.Get(Url);
            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Employees = JsonConvert.DeserializeObject<List<Employee>>(response.Result.Content.ReadAsStringAsync().Result);
            }

        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            var response = WebApi.Put<Employee>($"{Url}/{Selected.Id}", Selected);
            if (response.Result.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                MessageBox.Show($"{Selected.Fullname}'s details has successfully been updated!");
            }
            else
            {
                MessageBox.Show($"Failed to update {Selected.Fullname}'s details.");
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            var response = WebApi.Delete($"{Url}/{Selected.Id}");
            if (response.Result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show($"{Selected.Fullname}'s details has successfully been deleted!");
            }
            else
            {
                MessageBox.Show($"Failed to delete {Selected.Fullname}'s details.");
            }
        }
    }

    public class Employee
    {
        public long Id { get; set; }
        public string Fullname { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
    }
}

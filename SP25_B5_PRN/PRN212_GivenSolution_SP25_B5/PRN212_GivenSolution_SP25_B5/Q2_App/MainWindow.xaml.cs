using Q2_DataAcess.Models;
using Repository;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Q2_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EmployessRepo employessRepo = new EmployessRepo();
        private Employee currentEmployee;  // Thêm biến lưu nhân viên đang chọn

        public MainWindow()
        {
            InitializeComponent();
            LoadEmployee();
        }

        public void LoadEmployee()
        {
            var emp = employessRepo.GetAll();
            lvEmployees.ItemsSource = emp;
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadEmployee();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var newEmployee = new Employee
            {
                Name = txtName.Text,
                Sex = rbMale.IsChecked == true ? "Male" : "Female",
                Dob = dpDob.SelectedDate.HasValue ? DateOnly.FromDateTime(dpDob.SelectedDate.Value) : default,  // Convert DateTime to DateOnly
                Position = cbPosition.Text
            };

            employessRepo.Create(newEmployee);
            MessageBox.Show("Employee added successfully.");
            LoadEmployee(); // Reload the employee list
        }


        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (currentEmployee == null)
            {
                MessageBox.Show("Select an employee to edit.");
                return;
            }

            currentEmployee.Name = txtName.Text;
            currentEmployee.Sex = rbMale.IsChecked == true ? "Male" : "Female";
            currentEmployee.Dob = dpDob.SelectedDate.HasValue ? DateOnly.FromDateTime(dpDob.SelectedDate.Value) : default;  // Convert DateTime to DateOnly
            currentEmployee.Position = cbPosition.Text;

            employessRepo.Update(currentEmployee);
            MessageBox.Show("Employee updated successfully.");
            LoadEmployee(); // Reload the employee list
        }


        private void lvEmployees_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            currentEmployee = lvEmployees.SelectedItem as Employee;

            if (currentEmployee != null)
            {
                txtName.Text = currentEmployee.Name;
                cbPosition.Text = currentEmployee.Position;
                rbMale.IsChecked = currentEmployee.Sex == "Male";
                rbFemale.IsChecked = currentEmployee.Sex == "Female";

                // Fix for CS0029: Convert DateOnly to DateTime before assigning to dpDob.SelectedDate
                dpDob.SelectedDate = currentEmployee.Dob.ToDateTime(TimeOnly.MinValue);
            }
        }

    }
}
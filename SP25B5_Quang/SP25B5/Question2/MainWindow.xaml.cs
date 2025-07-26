using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Question2.Models;

namespace Question2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AppDbContext _context = new AppDbContext();

        public MainWindow()
        {
            InitializeComponent();
            load_Employees();
            load_Positions();
        }

        public class EmployeeDisplay()
        {
            public int Id { get; set; }
            public string Name { get; set; }

        public string Sex { get; set; }
        public DateTime Dob { get; set; }
        public string Position { get; set; }

        }

        public void load_Employees()
        {
            var employees = _context.Employee
                .Select(e => new EmployeeDisplay() {
                Id = e.Id,
                Name = e.Name,
                Sex = e.Sex,
                Dob = e.Dob,
                Position = e.Position,
            }).ToList();

            lvEmployees.ItemsSource = employees;
        }

        public void load_Positions()
        {
            var positions = _context.Employee
                .Select(e => e.Position)
                .Distinct()
                .Select(p => new { Position = p })
                .ToList();

            cbPosition.ItemsSource = positions;
            cbPosition.DisplayMemberPath = "Position";
            cbPosition.SelectedValuePath = "Position";
            if (positions.Count > 0)
                cbPosition.SelectedIndex = 0;
        }

        private void lvEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvEmployees.SelectedItem == null) return;

            var selectedEmployee = lvEmployees.SelectedItem as EmployeeDisplay;

            txtId.Text = selectedEmployee.Id.ToString();
            txtName.Text = selectedEmployee.Name;
            cbPosition.SelectedValue = selectedEmployee.Position;

            if (selectedEmployee.Sex == "Male")
            {
                rbMale.IsChecked = true;
            }
            else if (selectedEmployee.Sex == "Female")
            {
                rbFemale.IsChecked = true;
            }
            dpDob.Language = XmlLanguage.GetLanguage("en-GB");

            dpDob.SelectedDate = selectedEmployee.Dob;

            cbPosition.SelectedValue = selectedEmployee.Position;
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            txtId.Text = "";
            txtName.Text = "";
            rbMale.IsChecked = false;
            rbFemale.IsChecked = false;
            dpDob.SelectedDate = null;
            cbPosition.SelectedIndex = -1; 
            
            lvEmployees.SelectedItem = null;

            load_Employees();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var selectedEmployee = lvEmployees.SelectedItem as EmployeeDisplay;
            if (selectedEmployee == null)
            {
                MessageBox.Show("Please select an employee to edit.", "Thong bao", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtName.Text) || cbPosition.SelectedIndex == -1 || dpDob.SelectedDate == null)
            {
                MessageBox.Show("Please fill in all fields.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var employee = _context.Employee.FirstOrDefault(e => e.Id == selectedEmployee.Id);

            if (employee == null)
            {
                MessageBox.Show("Employee not found in the database.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            employee.Name = txtName.Text;
            employee.Dob = dpDob.SelectedDate.Value;
            employee.Dob = dpDob.SelectedDate.Value;

            if (rbMale.IsChecked == true)
                employee.Sex = "Male";
            else if (rbFemale.IsChecked == true)
                employee.Sex = "Female";
            try
            {
                _context.SaveChanges();
                MessageBox.Show("Employee updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                load_Employees();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating employee: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                dpDob.SelectedDate == null ||
                cbPosition.SelectedValue == null ||
                (rbMale.IsChecked == false && rbFemale.IsChecked == false))
            {
                MessageBox.Show("Please fill in all required fields.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string sex = rbMale.IsChecked == true ? "Male" : "Female";

            var newEmployee = new Employee
            {
                Name = txtName.Text.Trim(),
                Dob = dpDob.SelectedDate.Value,
                Sex = sex,
                Position = cbPosition.SelectedValue.ToString(),
                Department = null 
            };

            try
            {
                _context.Employee.Add(newEmployee);
                _context.SaveChanges();
                MessageBox.Show("Employee added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                load_Employees(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding employee: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
   
            var selectedEmployee = lvEmployees.SelectedItem as EmployeeDisplay;

            if (selectedEmployee == null)
            {
                MessageBox.Show("Please select an employee to delete.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            
            var confirm = MessageBox.Show($"Are you sure you want to delete employee '{selectedEmployee.Name}'?",
                                          "Confirm Delete", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (confirm == MessageBoxResult.Yes)
            {
                try
                {
                    var employee = _context.Employee.FirstOrDefault(e => e.Id == selectedEmployee.Id);
                    if (employee != null)
                    {
                        _context.Employee.Remove(employee);
                        _context.SaveChanges();
                        MessageBox.Show("Employee deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                        load_Employees(); 
                       
                    }
                    else
                    {
                        MessageBox.Show("Employee not found.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting employee: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

    }
}
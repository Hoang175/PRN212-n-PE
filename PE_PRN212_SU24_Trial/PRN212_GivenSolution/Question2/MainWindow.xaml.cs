using Microsoft.EntityFrameworkCore;
using Question2.Models;
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

namespace Question2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Prn212TrialContext con = new Prn212TrialContext();
        public MainWindow()
        {
            InitializeComponent();
            loadPage();
        }

        private void loadPage()
        {
            lvEmployee.ItemsSource = con.Employees.ToList();
        }

        private void lvEmployee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lvEmployee.SelectedItem is Employee selected)
            {
                DateTime.TryParse(selected.Dob.ToString(), out DateTime date);
                txtId.Text = selected.Id.ToString();
                txtName.Text = selected.Name;
                txtIdNumber.Text = selected.Idnumber.ToString();
                txtPhone.Text = selected.Phone;
                dpDob.SelectedDate = date;
                rbMale.IsChecked = true;
                rbFemale.IsChecked = selected.Gender.Equals("Female");
            }
        }

        private void clear()
        {
            txtId.Text = "";
            txtIdNumber.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
            rbFemale.IsChecked = false;
            rbMale.IsChecked = true;
            dpDob.SelectedDate = null;

        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(int.TryParse(txtId.Text, out int id))
            {
                
                Employee employee = con.Employees.Include(p => p.Services).FirstOrDefault(p => p.Id == id);
                if(employee.Services != null)
                {
                    con.Services.RemoveRange(employee.Services);
                }
                con.Employees.Remove(employee);
                con.SaveChanges();
                MessageBox.Show("delete thành công");
                clear();
                loadPage();
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if(int.TryParse(txtId.Text,out int id))
            {
                Employee employee = con.Employees.FirstOrDefault(x => x.Id == id);
                if(employee != null)
                {
                    //DateOnly.TryParse(dpDob.SelectedDate.Value.ToString(), out DateOnly date);
                    employee.Name = txtName.Text;
                    employee.Phone = txtPhone.Text;
                    employee.Idnumber = txtIdNumber.Text;
                    employee.Dob = DateOnly.FromDateTime(dpDob.SelectedDate.Value);
                    employee.Gender = rbMale.IsChecked == true ? "Male" : "Female";

                    con.Employees.Update(employee);
                    con.SaveChanges() ;
                    MessageBox.Show("Update thành cổng");
                    clear();
                    loadPage();

                    
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = new Employee();
            employee.Name = txtName.Text;   
            employee.Phone = txtPhone.Text;
            employee.Idnumber= txtIdNumber.Text;
            employee.Dob = DateOnly.FromDateTime(dpDob.SelectedDate.Value);
            employee.Gender = rbMale.IsChecked == true ? "Male" : "Female";

            con.Employees.Add(employee);
            con.SaveChanges();
            MessageBox.Show("Add thành cổng", "alert", MessageBoxButton.OK, MessageBoxImage.Information);
            clear();
            loadPage();
        }
    }
}
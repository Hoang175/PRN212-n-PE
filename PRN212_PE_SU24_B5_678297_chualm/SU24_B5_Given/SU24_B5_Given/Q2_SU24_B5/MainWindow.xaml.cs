using Q2_SU24_B5.Models;
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

namespace Q2_SU24_B5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public class EmployeeRepo {         // This class would typically contain methods to interact with the database
        // For example, methods to get, add, edit, and delete employees

        PePrn21224sumB5Context _context;

        public EmployeeRepo()
        {
            _context = new();
        }

        public List<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }
    }
    public partial class MainWindow : Window
    {
        EmployeeRepo emp = new EmployeeRepo();
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        public void LoadData()
        {
            var employee = emp.GetAll();
            lvEmployees.ItemsSource = employee;
        }

        // Định nghĩa phương thức xử lý sự kiện SelectionChanged
        private void lvEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Code xử lý sự kiện khi lựa chọn thay đổi trong ListView
        }

        // Định nghĩa phương thức xử lý sự kiện Click cho btnRefresh
        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            // Code xử lý sự kiện khi nhấn nút Refresh
        }

        // Định nghĩa phương thức xử lý sự kiện Click cho btnAdd
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // Code xử lý sự kiện khi nhấn nút Add
        }

        // Định nghĩa phương thức xử lý sự kiện Click cho btnEdit
        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            // Code xử lý sự kiện khi nhấn nút Edit
        }
    }
}
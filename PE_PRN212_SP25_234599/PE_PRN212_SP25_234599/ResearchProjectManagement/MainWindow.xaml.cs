using System.Windows;
using BAL.Services;
using DAL.Models;

namespace ResearchProjectManagement_SE171151
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public UserAccount UserAccount { get; set; }
        private readonly ResearchProjectService _service = new();

        public MainWindow()
        {
            InitializeComponent();
        }


        private void ResetListDataGrid()
        {
            List.ItemsSource = null;
            List.ItemsSource = _service.GetAll();
        }

        private void DisbaledButton()
        {
            SearchButton.IsEnabled = false;
            CreateButton.IsEnabled = false;
            UpdateButton.IsEnabled = false;
            DeleteButton.IsEnabled = false;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            var list = _service.GetAll(ProjectTitleTextBox.Text, ResearchFieldTextBox.Text);
            if (list.Any())
            {
                List.ItemsSource = null;
                List.ItemsSource = list;
            }
            else
            {
                ResetListDataGrid();
            }
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var item = List.SelectedItem as ResearchProject;
            if (item == null)
            {
                MessageBox.Show("Please select item!", "Warning", MessageBoxButton.OK);
                return;
            }

            var result = MessageBox.Show("Do you want to delete this research project?", "Confirm deletion", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                bool checkDelete = _service.Delete(item);
                if (checkDelete)
                {
                    ResetListDataGrid();
                }
            }
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            LoginWindw login = new();
            login.Show();
            this.Close();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            ResetListDataGrid();
            WelcomeLabel.Content = "Welcome, " + UserAccount.Email;
            if (UserAccount.Role != 2)
            {
                DisbaledButton();
            }
        }
    }
}

using Q2_DataAcces.Models;
using Reporitory;
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
         BookRepo repo;
        public MainWindow()
        {
            InitializeComponent();
           LoadDataGrid();
        }

        public void LoadDataGrid()
        {
            repo = new BookRepo();
           List<Book> listBook = repo.GetAll();
            dgData.ItemsSource = null; // Clear the existing ItemsSource
            dgData.ItemsSource = listBook;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Book book = new Book();


          //  book.BookId = int.Parse(txtBookID.Text); // Assuming txtBookId is a TextBox for BookId input
            book.Title = txtTitle.Text;
            book.Publisher = txtPublisher.Text;
            book.PublicationYear = int.Parse(txtPublicationYear.Text); // Assuming txtPublicationYear is a TextBox for PublicationYear input
            // Try to parse the publication year, if it fails, set it to null or handle the error as needed
            //if (int.TryParse(txtPublicationYear.Text, out int publicationYear))
            //{
            //    book.PublicationYear = publicationYear;
            //}
            //else
            //{
            //    book.PublicationYear = null; // or handle the error as needed
            //}
            repo.Create(book);
            LoadDataGrid(); // Reload the DataGrid to show the newly added book
        }
    }
}
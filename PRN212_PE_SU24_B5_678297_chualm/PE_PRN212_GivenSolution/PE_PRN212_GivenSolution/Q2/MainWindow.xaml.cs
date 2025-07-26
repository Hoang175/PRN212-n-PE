using Microsoft.EntityFrameworkCore;
using Q2_SP25_ThuVienBook.Models;
using System.Collections.Generic;  // Đảm bảo bạn đã import thư viện này
using System.Linq;  // Đảm bảo bạn đã import thư viện này
using System.Windows;

namespace Q2_SP25_ThuVienBook
{
    public class BookRepo
    {
        private LibraryManagementContext _context;

        public BookRepo()
        {
            _context = new LibraryManagementContext();  // Khởi tạo context
        }

        public List<Book> GetBooks()
        {
           // return _context.Books.ToList();  // Lấy danh sách sách từ cơ sở dữ liệu
            return _context.Books.Include(b => b.Genre).ToList();
        }
        public Author GetAuthor(int bookId) {
            return _context.Authors
                .Include(a => a.Books)
                .FirstOrDefault(a => a.Books.Any(b => b.BookId == bookId));
        }

        public List<BookCopy> GetBookCopies(int bookId)
        {
            return _context.BookCopies
                .Where(bc => bc.BookId == bookId)
                .ToList();
        }

        public List<BorrowHistory> GetBorrowHistories(int copyID)
        {
            return _context.BorrowHistories
                .Include(bh => bh.Copy)
                .Where(bh => bh.CopyId == copyID)
                .Include(bh => bh.Borrower)
                .ToList();
        }
    }

    public partial class MainWindow : Window
    {
        BookRepo bookRepo = new BookRepo();  // Khởi tạo đối tượng BookRepo

        public MainWindow()
        {
            InitializeComponent();  // Gọi phương thức để khởi tạo giao diện XAML
            LoadData();  // Tải dữ liệu sau khi giao diện đã được khởi tạo
        }

        public void LoadData()
        {
            var list = bookRepo.GetBooks();  // Lấy danh sách sách từ BookRepo
            dgBook.ItemsSource = list;  // Đặt ItemsSource của DataGrid là danh sách sách
        }

        private void btnView_Click(object sender, RoutedEventArgs e)
        {
            var select = dgBook.SelectedItem as Book;
            if (select == null) {
                MessageBox.Show("Please choice your selection!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                BorrowingHistoryDetails details = new BorrowingHistoryDetails(select);
                //details.Owner = this;
                //details.DataContext = select;
                details.ShowDialog();
            }
        }
    }
}

using Q2_SP25_ThuVienBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Q2_SP25_ThuVienBook
{
    /// <summary>
    /// Interaction logic for BorrowingHistoryDetails.xaml
    /// </summary>
    public partial class BorrowingHistoryDetails : Window
    {
        Book _selected;
        BookRepo repo;
        public BorrowingHistoryDetails( Book book)
        {
            InitializeComponent();
            _selected = book;
            repo = new BookRepo();
            LoadData();
        }

        public void LoadData()
        {
            valueID.Content = _selected.BookId;
            valueTitle.Content = _selected.Title;
            valueAuthor.Content = repo.GetAuthor(_selected.BookId).Name;
            dgBookCopy.ItemsSource = repo.GetBookCopies(_selected.BookId);
        }
    }
}

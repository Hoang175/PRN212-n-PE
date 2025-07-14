using Q2_DataAcces.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporitory
{
    public class BookRepo
    {
        PePrn24fallB1Context _context;

        public BookRepo()
        {
            _context = new PePrn24fallB1Context();
        }
        public void Create(Book book)
        {
            using (_context = new PePrn24fallB1Context())
            {
                _context.Books.Add(book);
                _context.SaveChanges();
            }
        }
        public List<Book> GetAll()
        {
           return _context.Books.ToList();
        }
    }
}

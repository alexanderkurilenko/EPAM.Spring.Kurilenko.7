using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Logic
{
    public class BookService
    {
        #region Fields and Prop
        private List<Book> books;
        public int Count { get; set; }
        #endregion

        #region Ctors
        public BookService()
        {
            books = new List<Book>();
            Count = books.Count;
        }

        public BookService(IEnumerable<Book> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException();
            }

            books = new List<Book>(collection);
        }
        #endregion

        #region Methods
        /// <summary>
        /// Add a book into rep
        /// </summary>
        /// <param name="book"></param>
        public void AddBook(Book book)
        {
            for (int i = 0; i < books.Count; i++)
            {
                if (Equals(book, books[i]))
                {
                    throw new ArgumentException("This book is exist");
                }
            }

            books.Add(book);
        }

        /// <summary>
        /// delete book
        /// </summary>
        /// <param name="book"></param>
        public void RemoveBook(Book book)
        {
            bool isBookDeleted = false;

            for (int i = 0; i < books.Count; i++)
            {
                if (Equals(book, books[i]))
                {
                    books.Remove(book);
                    isBookDeleted = true;
                }
            }

            if (!isBookDeleted)
            {
                throw new ArgumentException("This book isn't exist");
            }

        }

        /// <summary>
        /// Find book by tag
        /// </summary>
        /// <param name="checker"></param>
        /// <returns></returns>
        public List<Book> FindByTag(Predicate<Book> checker)
        {
            if (checker == null)
            {
                throw new ArgumentNullException();
            }

            List<Book> findedBooks = books.FindAll(checker);
            return findedBooks;

        }

        /// <summary>
        /// Sorting by comparator
        /// </summary>
        /// <param name="comparator"></param>
        public void SortBooksByTag(IComparer<Book> comparator)
        {
            if (comparator == null)
            {

                throw new ArgumentNullException();
            }

            books.Sort(comparator);

        }
        /// <summary>
        /// Read from a file
        /// </summary>
        /// <param name="filePath"></param>
        public void ReadFromStream(string filePath)
        {
            List<Book> temp = ReadBooks(filePath);

            if (temp == null)
            {
                
                throw new Exception("There is no data to load at " + filePath);
            }

            books = temp;
        }

        /// <summary>
        /// Write to file
        /// </summary>
        /// <param name="filePath"></param>
        public void WriteToStream(string filePath)
        {
            WriteBooks(books, filePath);
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Writing to file(private)
        /// </summary>
        /// <param name="books"></param>
        /// <param name="filePath"></param>
        private void WriteBooks(List<Book> books, string filePath)
        {
            if (filePath == "" && filePath == null)
            {
                throw new ArgumentNullException();
            }

            using (BinaryWriter writer = new BinaryWriter(new FileStream(filePath, FileMode.Create)))
            {
                for (int i = 0; i < books.Count; i++)
                {
                    if (books[i] != null)
                    {
                        writer.Write((books[i].Title));
                        writer.Write((books[i].Author));
                        writer.Write(books[i].Length.ToString());
                    }
                }
            }           
        }

        /// <summary>
        /// get data from file
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        private List<Book> ReadBooks(string filePath)
        {
            List<Book> books = new List<Book>();
            int countOfPages;

            if (!string.IsNullOrEmpty(filePath))
            {
                using (BinaryReader reader = new BinaryReader(new FileStream(filePath, FileMode.Open)))
                {
                    while (reader.PeekChar() > -1)
                    {
                        Book book = new Book();
                        book.Title = reader.ReadString();
                        book.Author = reader.ReadString();
                        int.TryParse(reader.ReadString(), out countOfPages);
                        book.Length = countOfPages;
                        books.Add(book);
                    }
                }

                return books;
            }
            throw new ArgumentNullException();
        }
        #endregion
    }

}

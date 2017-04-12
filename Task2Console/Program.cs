using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Logic;

namespace Task2Console
{
    class Program
    {
        static void Main(string[] args)
        {
            BookService books = new BookService();
            List<Book> founded = new List<Book>();
            books.AddBook(new Book() { Author = "Pushkin A", Title = "Evgeniy Onegin", Length = 200 });
            books.AddBook(new Book() { Author = "Dostoevsky ", Title = "Prestypleenie&nakazanie", Length = 500 });

            books.WriteToStream("test.txt");

            founded= books.FindByTag((book => book.Length > 400));

            for (int i = 0; i < founded.Count; i++)
            {
                Console.WriteLine(founded[i].ToString());
            }


        }
    }
}

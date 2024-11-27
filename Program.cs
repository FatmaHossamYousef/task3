using System.Net.Http.Headers;
using System.Threading.Channels;

namespace task3
{
    class Book
    {
        string title;
        string author;
        string ISBN;
        bool availability;

        public Book(string title = " ", string author = " ", string ISBN = " ", bool availability = true)
        {
            this.title = title;
            this.author = author;
            this.ISBN = ISBN;
            this.availability = availability;
        }

        public string GetTitle()
        {
            return title;
        }
        public string GetAuthor()
        {
            return author;
        }
        public string GetISBN()
        {
            return ISBN;
        }
        public bool GetVailability()
        {
            return availability;
        }



        public void SetTitle(string title)
        {
            this.title = title;
        }
        public void SetAuthor(string author)
        {
            this.author = author;
        }
        public void SetISBN(string ISBN)
        {
            this.ISBN = ISBN;
        }
        public void SetVailability(bool availability)
        {
            this.availability = availability;
        }
    }




    class Library
    {
        public List<Book> books;

        public Library()
        {
            this.books = new List<Book>();
        }

        // add book to library
        
        public void AddBook(Book book)
        {
            books.Add(book);
        }
        //طريقه تانيه 
        //public void AddBook (string title = " ", string author = " ", string ISBN = "", bool availability = true)

        //{
        //    Book book = new Book();
        //    book.SetTitle(title);
        //    book.SetAuthor(author);
        //    book.SetISBN(ISBN);
        //    book.SetVailability(availability);
        //    books.Add(book);
        //  }

        // search for book in library by title or author name

        public void SearchBook(string search)
        {
            bool found = false;
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].GetTitle().Contains(search) || books[i].GetAuthor().Contains(search))
                {// i use contains if user enter any part  of book name or outher name  program will return all possible answers

                    found = true;
                    Console.WriteLine();
                    Console.WriteLine(books[i].GetTitle());
                    Console.WriteLine(books[i].GetAuthor());
                    Console.WriteLine(books[i].GetISBN());
                    Console.WriteLine(books[i].GetVailability());
                    Console.WriteLine();
                }
            }
            Console.WriteLine("================");

            if (!found)
            {
                Console.WriteLine("\nbook not in library");
               
            }
        }
        //borrow book 
        public void BorrowBook(string search)
        {
            bool borrow = false;
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].GetTitle().Contains(search) &&  books[i].GetVailability()==true)
                {

                    books[i].SetVailability(false);
                    borrow = true;
                }
            }

            if (!borrow)
            {
                Console.WriteLine(" book is not in the library.");
            }
        }
        //return book
        public void ReturnBook(string search)
        {
            bool exist = false;
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].GetTitle().Contains(search) && books[i].GetVailability() == false)
                {
                    books[i].SetVailability(true);
                    exist = true;
                }
            }
            if (!exist)
            {
                Console.WriteLine(" book is not borrowed");
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();

            //Adding books to the library
            library.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565"));
            library.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084"));
            library.AddBook(new Book("1984", "George Orwell", "9780451524935"));
            library.AddBook(new Book("ozil", "George Orwell", "9780451545935"));


            //طريقه استخدام الطريقه التانيه
            //library.AddBook("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565");
            //library.AddBook("To Kill a Mockingbird", "Harper Lee", "9780061120084");
            //library.AddBook("1984", "George Orwell", "9780451524935");


            // Searching  books
            Console.WriteLine("searching result :-");
            library.SearchBook("Orwell");

            // borrowing  books
            Console.WriteLine("borrowing  books...");
            library.BorrowBook("Gatsby");
            library.BorrowBook("1984");
            library.BorrowBook("Harry Potter"); // This book is not in the library
            Console.WriteLine("\n================");


            // Returning books
            Console.WriteLine("Returning books...");
            library.ReturnBook("Gatsby");
            library.ReturnBook("Harry Potter"); // This book is not borrowed
            Console.WriteLine("\n================");


        }
    }
}

















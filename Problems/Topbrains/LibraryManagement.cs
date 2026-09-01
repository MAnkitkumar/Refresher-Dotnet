using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystem
{
    // Book class to represent a book entity
    class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Author: {Author}, Publisher: {Publisher}, Price: ${Price}";
        }
    }

    // Library class to manage book operations
    class Library
    {
        private List<Book> books = new List<Book>();
        private int nextId = 1;

        // Admin: Add Book
        public void AddBook(string name, string author, string publisher, double price)
        {
            dynamic book = new Book
            {
                Id = nextId++,
                Name = name,
                Author = author,
                Publisher = publisher,
                Price = price
            };
            books.Add(book);
            Console.WriteLine($"\n✓ Book added successfully! (ID: {book.Id})");
        }

        // Admin: Update Book
        public void UpdateBook(int id, string name, string author, string publisher, double price)
        {
            Book book = books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                book.Name = name;
                book.Author = author;
                book.Publisher = publisher;
                book.Price = price;
                Console.WriteLine("\n✓ Book updated successfully!");
            }
            else
            {
                Console.WriteLine("\n✗ Book not found!");
            }
        }

        // Admin: Delete Book
        public void DeleteBook(int id)
        {
            Book book = books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                books.Remove(book);
                Console.WriteLine("\n✓ Book deleted successfully!");
            }
            else
            {
                Console.WriteLine("\n✗ Book not found!");
            }
        }

        // Admin & User: View All Books
        public void ViewAllBooks()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("\nNo books available in the library.");
                return;
            }

            Console.WriteLine("\n========== ALL BOOKS ==========");
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine("================================");
        }

        // User: Search Book by Name
        public void SearchByName(string name)
        {
            var result = books.Where(b => b.Name.ToLower().Contains(name.ToLower())).ToList();
            
            if (result.Count == 0)
            {
                Console.WriteLine("\n✗ No books found with that name.");
                return;
            }

            Console.WriteLine($"\n========== SEARCH RESULTS (Name: {name}) ==========");
            foreach (var book in result)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine("====================================================");
        }

        // User: Search Book by Publisher
        public void SearchByPublisher(string publisher)
        {
            var result = books.Where(b => b.Publisher.ToLower().Contains(publisher.ToLower())).ToList();
            
            if (result.Count == 0)
            {
                Console.WriteLine("\n✗ No books found from that publisher.");
                return;
            }

            Console.WriteLine($"\n========== SEARCH RESULTS (Publisher: {publisher}) ==========");
            foreach (var book in result)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine("==============================================================");
        }

        // User: View Highest Price Book
        public void ViewHighestPriceBook()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("\nNo books available.");
                return;
            }

            Book highest = books.OrderByDescending(b => b.Price).First();
            Console.WriteLine("\n========== HIGHEST PRICE BOOK ==========");
            Console.WriteLine(highest);
            Console.WriteLine("=========================================");
        }

        // User: View Lowest Price Book
        public void ViewLowestPriceBook()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("\nNo books available.");
                return;
            }

            Book lowest = books.OrderBy(b => b.Price).First();
            Console.WriteLine("\n========== LOWEST PRICE BOOK ==========");
            Console.WriteLine(lowest);
            Console.WriteLine("========================================");
        }
    }

    class Program
    {
        static Library library = new Library();

        static void Main(string[] args)
        {
            // Pre-populate with sample data
            library.AddBook("The Great Gatsby", "F. Scott Fitzgerald", "Scribner", 15.99);
            library.AddBook("To Kill a Mockingbird", "Harper Lee", "J.B. Lippincott", 18.99);
            library.AddBook("1984", "George Orwell", "Secker & Warburg", 14.50);
            library.AddBook("Pride and Prejudice", "Jane Austen", "T. Egerton", 12.99);
            library.AddBook("The Catcher in the Rye", "J.D. Salinger", "Little, Brown", 16.50);

            while (true)
            {
                Console.WriteLine("\n╔════════════════════════════════════════╗");
                Console.WriteLine("║  BOOK LIBRARY MANAGEMENT SYSTEM       ║");
                Console.WriteLine("╚════════════════════════════════════════╝");
                Console.WriteLine("1. Admin Login");
                Console.WriteLine("2. User Login");
                Console.WriteLine("3. Exit");
                Console.Write("\nEnter your choice: ");
                
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AdminMenu();
                        break;
                    case "2":
                        UserMenu();
                        break;
                    case "3":
                        Console.WriteLine("\nThank you for using the Library Management System!");
                        return;
                    default:
                        Console.WriteLine("\n✗ Invalid choice! Please try again.");
                        break;
                }
            }
        }

        static void AdminMenu()
        {
            while (true)
            {
                Console.WriteLine("\n╔════════════════════════════════════════╗");
                Console.WriteLine("║          ADMIN MENU                   ║");
                Console.WriteLine("╚════════════════════════════════════════╝");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Update Book");
                Console.WriteLine("3. Delete Book");
                Console.WriteLine("4. View All Books");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("\nEnter your choice: ");
                
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddBookMenu();
                        break;
                    case "2":
                        UpdateBookMenu();
                        break;
                    case "3":
                        DeleteBookMenu();
                        break;
                    case "4":
                        library.ViewAllBooks();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("\n✗ Invalid choice! Please try again.");
                        break;
                }
            }
        }

        static void UserMenu()
        {
            while (true)
            {
                Console.WriteLine("\n╔════════════════════════════════════════╗");
                Console.WriteLine("║          USER MENU                    ║");
                Console.WriteLine("╚════════════════════════════════════════╝");
                Console.WriteLine("1. Browse All Books");
                Console.WriteLine("2. Search Book by Name");
                Console.WriteLine("3. Search Book by Publisher");
                Console.WriteLine("4. View Highest Price Book");
                Console.WriteLine("5. View Lowest Price Book");
                Console.WriteLine("6. Back to Main Menu");
                Console.Write("\nEnter your choice: ");
                
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        library.ViewAllBooks();
                        break;
                    case "2":
                        Console.Write("\nEnter book name to search: ");
                        string name = Console.ReadLine();
                        library.SearchByName(name);
                        break;
                    case "3":
                        Console.Write("\nEnter publisher name to search: ");
                        string publisher = Console.ReadLine();
                        library.SearchByPublisher(publisher);
                        break;
                    case "4":
                        library.ViewHighestPriceBook();
                        break;
                    case "5":
                        library.ViewLowestPriceBook();
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("\n✗ Invalid choice! Please try again.");
                        break;
                }
            }
        }

        static void AddBookMenu()
        {
            Console.Write("\nEnter Book Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Author: ");
            string author = Console.ReadLine();
            Console.Write("Enter Publisher: ");
            string publisher = Console.ReadLine();
            Console.Write("Enter Price: $");
            double price = double.Parse(Console.ReadLine());

            library.AddBook(name, author, publisher, price);
        }

        static void UpdateBookMenu()
        {
            Console.Write("\nEnter Book ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter New Book Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter New Author: ");
            string author = Console.ReadLine();
            Console.Write("Enter New Publisher: ");
            string publisher = Console.ReadLine();
            Console.Write("Enter New Price: $");
            double price = double.Parse(Console.ReadLine());

            library.UpdateBook(id, name, author, publisher, price);
        }

        static void DeleteBookMenu()
        {
            Console.Write("\nEnter Book ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            library.DeleteBook(id);
        }
    }
}

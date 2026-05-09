using Library;

namespace LibraryUsage;

/// <summary>
/// Provides the entry point for the application.
/// </summary>
class Program
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        LibrarySys library = new LibrarySys();

        Student student1 = new Student("Петро", "Шевченко", "ІП-51");
        Student student2 = new Student("Ірина", "Коваленко", "ІП-52");
        Student student3 = new Student("Анна", "Петренко", "ІП-67");
        
        library.AddUser(student1);
        library.AddUser(student2);
        library.AddUser(student3);

        student1.LastName = "Бондаренко"; 

        Book book1 = new Book("Книжка1", "Джейн Д.", "978-5-8459-2042-1");
        Book book2 = new Book("Книжка про ООП", "Джон Д.", "978-5-496-00435-0");
        Book book3 = new Book("Енциклопедія", "Джинні Д.", "978-5-496-00435-1");
        
        library.AddDocument(book1);
        library.AddDocument(book2);
        library.AddDocument(book3);

        book3.Title = "Енциклопедія (том 2)";

        Console.WriteLine("--- Users (sorted by last name) ---");
        foreach (var user in library.GetUsersSortedByLastName())
        {
            user.PrintUserInfo();
        }

        Console.WriteLine("\n--- Users (sorted by academic group) ---");
        foreach (var student in library.GetStudentsSortedByGroup())
        {
            student.PrintUserInfo();
        }

        Console.WriteLine("\n--- Documents (sorted by title) ---");
        foreach (var doc in library.GetDocumentsSortedByTitle())
        {
            doc.DisplayInfo();
        }

        Console.WriteLine("\n--- Borrowing books ---");
        try
        {
            library.BorrowDocument(student1, book1);
            Console.WriteLine($"Student '{student1.FirstName}' borrowed book '{book1.Title}'");
            
            library.BorrowDocument(student2, book2);
            Console.WriteLine($"Student '{student2.FirstName}' borrowed book '{book2.Title}'");

            Console.WriteLine($"-> Attempt to borrow book '{book1.Title}' to student '{student3.FirstName}':");
            library.BorrowDocument(student3, book1);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[EXCEPTION CAUGHT]: {ex.Message}");
        }


        Console.WriteLine("\n--- Checking status of a specific document ---");
        bool isBorrowed = library.IsDocumentBorrowed(book1);
        if (isBorrowed)
        {
            User borrower = library.GetUserWhoBorrowed(book1);
            Console.WriteLine($"Book '{book1.Title}' is borrowed by: {borrower.FirstName} {borrower.LastName}");
        }
        else
        {
            Console.WriteLine($"Book '{book1.Title}' is available in the library.");
        }

        Console.WriteLine("\n--- Returning a book to the library ---");
        library.ReturnDocument(student1, book1);
        Console.WriteLine($"Book '{book1.Title}' has been returned.");
        
        SearchService searchService = new SearchService();
        library.SearchAndPrintDocuments(searchService, "Книжка");
        library.SearchAndPrintUsers(searchService, "Бондаренко");
        library.SearchAndPrintUsers(searchService, "Шевченко");
    }
}

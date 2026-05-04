namespace Library;

/// <summary>
/// Represents an abstract document in the library.
/// </summary>
public abstract class Document : ILibraryItem
{
    /// <summary>
    /// Gets the unique identifier for the document.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Gets or sets the title of the document.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Gets or sets the author of the document.
    /// </summary>
    public string Author { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Document"/> class.
    /// </summary>
    /// <param name="title">The title of the document.</param>
    /// <param name="author">The author of the document.</param>
    protected Document(string title, string author)
    {
        Id = Guid.NewGuid();
        Title = title;
        Author = author;
    }

    /// <summary>
    /// Displays information about the document.
    /// </summary>
    public abstract void DisplayInfo();
}

/// <summary>
/// Represents a book in the library.
/// </summary>
public class Book : Document
{
    /// <summary>
    /// Gets or sets the ISBN of the book.
    /// </summary>
    public string ISBN { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Book"/> class.
    /// </summary>
    /// <param name="title">The title of the book.</param>
    /// <param name="author">The author of the book.</param>
    /// <param name="isbn">The ISBN of the book.</param>
    public Book(string title, string author, string isbn) : base(title, author)
    {
        ISBN = isbn;
    }

    /// <summary>
    /// Displays information about the book.
    /// </summary>
    public override void DisplayInfo()
    {
        Console.WriteLine($"[Book] '{Title}', Author: {Author}, ISBN: {ISBN}");
    }
}

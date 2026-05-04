namespace Library;

/// <summary>
/// Represents a user's library card holding borrowed documents.
/// </summary>
public class LibraryCard
{
    private const int MaxDocuments = 5;
    
    /// <summary>
    /// Gets the list of borrowed documents.
    /// </summary>
    public List<Document> BorrowedDocuments { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="LibraryCard"/> class.
    /// </summary>
    public LibraryCard()
    {
        BorrowedDocuments = new List<Document>();
    }

    /// <summary>
    /// Adds a document to the library card.
    /// </summary>
    /// <param name="doc">The document to add.</param>
    /// <exception cref="LibraryLimitException">Thrown when the maximum number of documents is reached.</exception>
    public void AddDocument(Document doc)
    {
        if (BorrowedDocuments.Count >= MaxDocuments)
            throw new LibraryLimitException($"Limit exceeded. Cannot borrow more than {MaxDocuments} documents.");

        BorrowedDocuments.Add(doc);
    }

    /// <summary>
    /// Removes a document from the library card.
    /// </summary>
    /// <param name="doc">The document to remove.</param>
    /// <exception cref="ArgumentException">Thrown when the document is not found on the library card.</exception>
    public void RemoveDocument(Document doc)
    {
        if (!BorrowedDocuments.Contains(doc))
            throw new ArgumentException("Document not found on the user's library card.");

        BorrowedDocuments.Remove(doc);
    }
}

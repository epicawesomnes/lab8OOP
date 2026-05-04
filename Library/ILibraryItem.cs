namespace Library;

/// <summary>
/// Represents an item in the library.
/// </summary>
public interface ILibraryItem
{
    /// <summary>
    /// Gets or sets the title of the item.
    /// </summary>
    string Title { get; set; }

    /// <summary>
    /// Gets or sets the author of the item.
    /// </summary>
    string Author { get; set; }

    /// <summary>
    /// Displays information about the item.
    /// </summary>
    void DisplayInfo();
}
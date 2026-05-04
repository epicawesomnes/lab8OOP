namespace Library;

/// <summary>
/// Provides searching capabilities for library documents and users.
/// </summary>
public class SearchService
{
    /// <summary>
    /// Searches for documents that match the specified keyword in the title or author.
    /// </summary>
    /// <param name="documents">The sequence of documents to search.</param>
    /// <param name="keyword">The keyword to search for.</param>
    /// <returns>A list of matching documents.</returns>
    public List<Document> SearchDocuments(IEnumerable<Document> documents, string keyword)
    {
        return documents
            .Where(d => d.Title.Contains(keyword, StringComparison.OrdinalIgnoreCase) || 
                        d.Author.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    /// <summary>
    /// Searches for users that match the specified keyword in the first name or last name.
    /// </summary>
    /// <param name="users">The sequence of users to search.</param>
    /// <param name="keyword">The keyword to search for.</param>
    /// <returns>A list of matching users.</returns>
    public List<User> SearchUsers(IEnumerable<User> users, string keyword)
    {
        return users
            .Where(u => u.FirstName.Contains(keyword, StringComparison.OrdinalIgnoreCase) || 
                        u.LastName.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}

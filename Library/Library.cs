using System;
using System.Collections.Generic;
using System.Linq;

namespace Library
{

    /// <summary>
    /// Represents the main library system that manages documents and users.
    /// </summary>
    public class LibrarySys
    {
        private readonly List<Document> _documents;
        private readonly List<User> _users;

        /// <summary>
        /// Initializes a new instance of the <see cref="LibrarySys"/> class.
        /// </summary>
        public LibrarySys()
        {
            _documents = new List<Document>();
            _users = new List<User>();
        }

        /// <summary>
        /// Adds a user to the library.
        /// </summary>
        /// <param name="user">The user to add.</param>
        public void AddUser(User user) => _users.Add(user);

        /// <summary>
        /// Removes a user from the library.
        /// </summary>
        /// <param name="user">The user to remove.</param>
        public void RemoveUser(User user) => _users.Remove(user);

        /// <summary>
        /// Gets all users in the library.
        /// </summary>
        /// <returns>A sequence of all users.</returns>
        public IEnumerable<User> GetAllUsers() => _users;

        /// <summary>
        /// Gets all users sorted by their first name.
        /// </summary>
        /// <returns>A sequence of users sorted by first name.</returns>
        public IEnumerable<User> GetUsersSortedByFirstName() => _users.OrderBy(u => u.FirstName);

        /// <summary>
        /// Gets all users sorted by their last name.
        /// </summary>
        /// <returns>A sequence of users sorted by last name.</returns>
        public IEnumerable<User> GetUsersSortedByLastName() => _users.OrderBy(u => u.LastName);

        /// <summary>
        /// Gets all student users sorted by their academic group.
        /// </summary>
        /// <returns>A sequence of students sorted by academic group.</returns>
        public IEnumerable<Student> GetStudentsSortedByGroup() => _users.OfType<Student>().OrderBy(s => s.AcademicGroup);

        /// <summary>
        /// Adds a document to the library.
        /// </summary>
        /// <param name="doc">The document to add.</param>
        public void AddDocument(Document doc) => _documents.Add(doc);

        /// <summary>
        /// Removes a document from the library.
        /// </summary>
        /// <param name="doc">The document to remove.</param>
        public void RemoveDocument(Document doc) => _documents.Remove(doc);

        /// <summary>
        /// Gets all documents in the library.
        /// </summary>
        /// <returns>A sequence of all documents.</returns>
        public IEnumerable<Document> GetAllDocuments() => _documents;
        
        /// <summary>
        /// Gets all documents sorted by their title.
        /// </summary>
        /// <returns>A sequence of documents sorted by title.</returns>
        public IEnumerable<Document> GetDocumentsSortedByTitle() => _documents.OrderBy(d => d.Title);

        /// <summary>
        /// Gets all documents sorted by their author.
        /// </summary>
        /// <returns>A sequence of documents sorted by author.</returns>
        public IEnumerable<Document> GetDocumentsSortedByAuthor() => _documents.OrderBy(d => d.Author);

        /// <summary>
        /// Registers that a user borrows a document.
        /// </summary>
        /// <param name="user">The user borrowing the document.</param>
        /// <param name="doc">The document being borrowed.</param>
        /// <exception cref="InvalidOperationException">Thrown when the document does not belong to the library or is already borrowed.</exception>
        public void BorrowDocument(User user, Document doc)
        {
            if (!_documents.Contains(doc))
                throw new InvalidOperationException("Error: this document does not belong to this library.");

            if (IsDocumentBorrowed(doc))
                throw new InvalidOperationException("Error: document is already borrowed by another user.");

            user.Card.AddDocument(doc);
        }

        /// <summary>
        /// Registers that a user returns a document.
        /// </summary>
        /// <param name="user">The user returning the document.</param>
        /// <param name="doc">The document being returned.</param>
        public void ReturnDocument(User user, Document doc)
        {
            user.Card.RemoveDocument(doc);
        }

        /// <summary>
        /// Checks if a document is currently borrowed by any user.
        /// </summary>
        /// <param name="doc">The document to check.</param>
        /// <returns><c>true</c> if the document is borrowed; otherwise, <c>false</c>.</returns>
        public bool IsDocumentBorrowed(Document doc)
        {
            // Перевіряємо, чи є документ у чиємусь формулярі
            return _users.Any(u => u.Card.BorrowedDocuments.Contains(doc));
        }

        /// <summary>
        /// Gets the user who currently borrowed the specified document.
        /// </summary>
        /// <param name="doc">The document to lookup.</param>
        /// <returns>The user who borrowed the document, or null if it is not borrowed.</returns>
        public User GetUserWhoBorrowed(Document doc)
        {
            return _users.FirstOrDefault(u => u.Card.BorrowedDocuments.Contains(doc))!;
        }

        /// <summary>
        /// Searches for documents and prints the results to the console.
        /// </summary>
        /// <param name="searchService">The search service to use.</param>
        /// <param name="keyword">The keyword to search for.</param>
        public void SearchAndPrintDocuments(SearchService searchService, string keyword)
        {
            var results = searchService.SearchDocuments(_documents, keyword);
            Console.WriteLine($"\n--- Document search results for keyword '{keyword}' ---");
            
            if(!results.Any()) Console.WriteLine("Nothing found.");
            foreach (var r in results) r.DisplayInfo();
        }

        /// <summary>
        /// Searches for users and prints the results to the console.
        /// </summary>
        /// <param name="searchService">The search service to use.</param>
        /// <param name="keyword">The keyword to search for.</param>
        public void SearchAndPrintUsers(SearchService searchService, string keyword)
        {
            var results = searchService.SearchUsers(_users, keyword);
            Console.WriteLine($"\n--- User search results for keyword '{keyword}' ---");
            
            if(!results.Any()) Console.WriteLine("Nothing found.");
            foreach (var r in results) r.PrintUserInfo();
        }
    }
}
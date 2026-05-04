using System.Diagnostics.Contracts;
using System.Diagnostics.Tracing;

namespace Library;

/// <summary>
/// The exception that is thrown when a library limit is exceeded.
/// </summary>
public class LibraryLimitException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LibraryLimitException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public LibraryLimitException(string message) : base(message) { }
}


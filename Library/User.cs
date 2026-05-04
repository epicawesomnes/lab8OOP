namespace Library;

/// <summary>
/// Represents an abstract user of the library.
/// </summary>
public abstract class User
{
    /// <summary>
    /// Gets the unique identifier for the user.
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Gets or sets the first name of the user.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name of the user.
    /// </summary>
    public string LastName { get; set; }
    
    /// <summary>
    /// Gets the library card for the user.
    /// </summary>
    public LibraryCard Card { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="User"/> class.
    /// </summary>
    /// <param name="firstName">The first name of the user.</param>
    /// <param name="lastName">The last name of the user.</param>
    protected User(string firstName, string lastName)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Card = new LibraryCard();
    }

    /// <summary>
    /// Prints information about the user.
    /// </summary>
    public abstract void PrintUserInfo();
}

/// <summary>
/// Represents a student user of the library.
/// </summary>
public class Student : User
{
    /// <summary>
    /// Gets or sets the academic group of the student.
    /// </summary>
    public string AcademicGroup { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Student"/> class.
    /// </summary>
    /// <param name="firstName">The first name of the student.</param>
    /// <param name="lastName">The last name of the student.</param>
    /// <param name="academicGroup">The academic group of the student.</param>
    public Student(string firstName, string lastName, string academicGroup) : base(firstName, lastName)
    {
        AcademicGroup = academicGroup;
    }

    /// <summary>
    /// Prints information about the student.
    /// </summary>
    public override void PrintUserInfo()
    {
        Console.WriteLine($"[Student] {FirstName} {LastName}, Group: {AcademicGroup}");
    }
}

namespace SmartSchool.Students.Domain.Models;

public class Student
{
    public int Id { get; set; }
    public required string RollNumber { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int Age => CalculateAge();
    public string? PhoneNumber { get; set; }
    public Address? Address { get; set; }
    public ICollection<Relative> Relatives { get; set; } = [];

    public static Student Create(string roleNumber, string firstName, string lastName,
        DateTime dateOfBirth)
    {
        return new Student
        {
            RollNumber = roleNumber,
            FirstName = firstName,
            LastName = lastName,
            DateOfBirth = dateOfBirth
        };
    }

    private int CalculateAge()
    {
        var currentDate = DateTime.UtcNow;
        var age = currentDate.Year - DateOfBirth.Year;
        if (currentDate.Month < DateOfBirth.Month || 
            (currentDate.Month == DateOfBirth.Month && currentDate.Day < DateOfBirth.Day))
        {
            age--;
        }

        return age;
    }

}

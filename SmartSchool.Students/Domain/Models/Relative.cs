namespace SmartSchool.Students.Domain.Models;

public class Relative
{
    public int Id { get; set; }
    public bool IsGuardian { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public RelativeType RelationshipToStudent { get; set; }
    public ICollection<Student> Siblings { get; set; } = [];
}

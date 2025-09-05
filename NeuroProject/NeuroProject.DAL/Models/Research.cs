namespace NeuroProject.DAL.Models;

public class Research
{
    public Guid Id { get; set; }
    public Guid AuthorId { get; set; } 
    public string Title { get; set; }
    public DateTime Start { get; set; }
    public DateTime? End { get; set; }
    public ICollection<TestSubject> TestSubjects { get; set; }
}
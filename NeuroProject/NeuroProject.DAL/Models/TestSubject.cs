using NeuroProject.DAL.Enums;

namespace NeuroProject.DAL.Models;


public class TestSubject
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public TestSubjectCategories Category { get; set; }
    public double Weight { get; set; }
    public double Height { get; set; }
    public double Age { get; set; }
    public Guid ResearchId { get; set; }
    public Research Research { get; set; }
    public ICollection<Record> Records { get; set; }
}
using NeuroProject.DAL.Enums;

namespace NeuroProject.DAL.Models;

public class Record
{
    public Guid Id { get; set; }
    public RecordCategories Category { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public string Hash { get; set; }
    public double MetaFileSize { get; set; }
    public Guid TestSubjectId { get; set; }
    public TestSubject TestSubject { get; set; }
}
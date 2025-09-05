using NeuroProject.Web.Enums;

namespace NeuroProject.Web.Dto.Response;

public class RecordDto
{
    public Guid Id { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public RecordCategories Category { get; set; }
    public string Hash { get; set; }
    public double MetaFileSize { get; set; }
    public Guid TestSubjectId { get; set; }
}
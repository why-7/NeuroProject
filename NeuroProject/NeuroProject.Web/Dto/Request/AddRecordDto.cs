using NeuroProject.Web.Enums;

namespace NeuroProject.Web.Dto;

public class AddRecordDto
{
    public Guid TestSubjectId { get; set; }
    public IFormFile FileRecord { get; set; }
    public RecordCategories Category { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
}
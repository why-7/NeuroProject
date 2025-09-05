using NeuroProject.BLL.Enums;

namespace NeuroProject.BLL.BusinessModels;

public class RecordBm
{
    public Guid Id { get; set; }
    public Guid TestSubjectId { get; set; }
    public byte[] FileBytes { get; set; }
    public RecordCategories Category { get; set; }
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public string Hash { get; set; }
    public double MetaFileSize { get; set; }
}
using NeuroProject.BLL.Enums;

namespace NeuroProject.BLL.BusinessModels;

public class TestSubjecBm
{
    public Guid TestSubjectId { get; set; }
    public string Name { get; set; }
    public TestSubjectCategories Category { get; set; }
    public double Weight { get; set; }
    public double Length { get; set; }
    public double Age { get; set; }
}
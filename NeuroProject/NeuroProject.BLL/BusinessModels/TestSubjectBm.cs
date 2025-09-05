using NeuroProject.BLL.Enums;

namespace NeuroProject.BLL.BusinessModels;

public class TestSubjectBm
{
    public Guid Id { get; set; }
    public Guid ResearchId { get; set; }
    public string Name { get; set; }
    public TestSubjectCategories Category { get; set; }
    public double Weight { get; set; }
    public double Height { get; set; }
    public double Age { get; set; }
}
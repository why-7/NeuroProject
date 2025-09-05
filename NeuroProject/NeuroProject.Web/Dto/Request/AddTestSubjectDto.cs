using NeuroProject.Web.Enums;

namespace NeuroProject.Web.Dto;

public class AddTestSubjectDto
{
    public string Name { get; set; }
    public Guid ResearchId { get; set; }
    public TestSubjectCategories Category { get; set; }
    public double Weight { get; set; }
    public double Height { get; set; }
    public double Age { get; set; }
}
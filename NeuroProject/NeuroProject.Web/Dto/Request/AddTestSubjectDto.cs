using NeuroProject.Web.Enums;

namespace NeuroProject.Web.Dto;

public class AddTestSubjectDto
{
    public string Name { get; set; }
    public TestSubjectCategories Category { get; set; }
    public double Weight { get; set; }
    public double Length { get; set; }
    public double Age { get; set; }
}
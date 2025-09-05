using NeuroProject.Web.Enums;

namespace NeuroProject.Web.Dto.Response;

public class TestSubjectDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public TestSubjectCategories Category { get; set; }
    public double Weight { get; set; }
    public double Length { get; set; }
    public double Age { get; set; }
}
namespace NeuroProject.Web.Dto.Response;

public class ResearchDto
{
    public string Title { get; set; }
    public Guid AuthorId { get; set; }
    public Guid Id { get; set; }
    public DateTime Start { get; set; }
    public DateTime? End { get; set; }
}
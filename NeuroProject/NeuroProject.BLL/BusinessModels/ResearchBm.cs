using NeuroProject.BLL.Enums;

namespace NeuroProject.BLL.BusinessModels;

public class ResearchBm
{
    public string ResearchName { get; set; }
    public Guid AuthorId { get; set; }
    public Guid ResearchId { get; set; }

}
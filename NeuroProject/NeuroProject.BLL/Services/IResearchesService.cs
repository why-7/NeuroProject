using NeuroProject.BLL.BusinessModels;

namespace NeuroProject.BLL.Services;

public interface IResearchesService
{
    public Guid CreateNewResearch(ResearchBm researchBm);
    public Guid AddTestSubject(TestSubjecBm map);
    public Guid AddRecord(RecordBm map);
}
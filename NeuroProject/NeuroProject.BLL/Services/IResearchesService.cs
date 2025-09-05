using NeuroProject.BLL.BusinessModels;

namespace NeuroProject.BLL.Services;

public interface IResearchesService
{
    public Guid CreateNewResearch(ResearchBm researchBm);
    public Guid AddTestSubject(TestSubjectBm map);
    public Guid AddRecord(RecordBm map);
    public IEnumerable<ResearchBm> GetResearches(Guid userId);
    public IEnumerable<TestSubjectBm> GetTestSubjects(Guid researchId);
    public IEnumerable<RecordBm> GetRecords(Guid testSubjectId);
}
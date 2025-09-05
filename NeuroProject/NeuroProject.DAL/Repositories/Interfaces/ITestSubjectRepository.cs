using NeuroProject.DAL.Models;

namespace NeuroProject.DAL.Repositories.Interfaces;

public interface ITestSubjectRepository
{
    void Add(TestSubject testSubject);
    IEnumerable<TestSubject> GetAllById(Guid researchId);

}
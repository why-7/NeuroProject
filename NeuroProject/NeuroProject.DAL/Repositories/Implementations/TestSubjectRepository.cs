using NeuroProject.DAL.Models;
using NeuroProject.DAL.Repositories.Interfaces;

namespace NeuroProject.DAL.Repositories.Implementations;

public class TestSubjectRepository : ITestSubjectRepository
{
    private ResearchesDbContext _context;
    
    public TestSubjectRepository(ResearchesDbContext context)
    {
        _context = context;
    }
    public void Add(TestSubject testSubject)
    {
        _context.TestSubjects.Add(testSubject);
    }
}
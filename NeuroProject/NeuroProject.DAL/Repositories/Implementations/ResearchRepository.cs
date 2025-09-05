using NeuroProject.DAL.Models;
using NeuroProject.DAL.Repositories.Interfaces;

namespace NeuroProject.DAL.Repositories.Implementations;

public class ResearchRepository : IResearchRepository
{
    private ResearchesDbContext _context;
    
    public ResearchRepository(ResearchesDbContext context)
    {
        _context = context;
    }
    
    public void Add(Research research)
    {
        _context.Researches.Add(research);
        _context.SaveChanges();
    }

    public IEnumerable<Research> GetAllById(Guid id)
    {
        return _context.Researches.Where(x => x.AuthorId == id).AsEnumerable();
    }
}
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
    }
}
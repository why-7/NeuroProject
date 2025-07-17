using NeuroProject.DAL.Models;
using NeuroProject.DAL.Repositories.Interfaces;

namespace NeuroProject.DAL.Repositories.Implementations;

public class RecordRepository : IRecordRepository
{
    private ResearchesDbContext _context;
    
    public RecordRepository(ResearchesDbContext context)
    {
        _context = context;
    }
    
    public void Add(Record record)
    {
        _context.Records.Add(record);
    }
}
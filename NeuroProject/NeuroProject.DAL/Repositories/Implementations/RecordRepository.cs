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
    
    public async Task Add(Record record)
    {
        await _context.Records.AddAsync(record);
        await _context.SaveChangesAsync();
    }

    public IEnumerable<Record> GetAllById(Guid testSubjectId)
    {
        return _context.Records.Where(x => x.TestSubjectId == testSubjectId).AsEnumerable();
    }
}
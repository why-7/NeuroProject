using NeuroProject.DAL.Models;

namespace NeuroProject.DAL.Repositories.Interfaces;

public interface IRecordRepository
{
    Task Add(Record map);
    IEnumerable<Record> GetAllById(Guid testSubjectId);
}
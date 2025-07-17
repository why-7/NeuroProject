using NeuroProject.DAL.Models;

namespace NeuroProject.DAL.Repositories.Interfaces;

public interface IRecordRepository
{
    void Add(Record map);
}
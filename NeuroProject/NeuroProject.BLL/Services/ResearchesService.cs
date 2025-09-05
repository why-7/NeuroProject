using AutoMapper;
using NeuroProject.BLL.BusinessModels;
using NeuroProject.DAL;
using NeuroProject.DAL.Models;
using NeuroProject.DAL.Repositories.Implementations;
using NeuroProject.DAL.Repositories.Interfaces;

namespace NeuroProject.BLL.Services;

public class ResearchesService : IResearchesService
{
    private readonly IResearchRepository _researchRepository;
    private readonly IMapper _mapper;
    private readonly ITestSubjectRepository _testSubjectRepository;
    private readonly IRecordRepository _recordRepository;
    
    public ResearchesService(IMapper mapper, IResearchRepository researchRepository,
        ITestSubjectRepository testSubjectRepository, IRecordRepository recordRepository)
    {
        _researchRepository = researchRepository;
        _mapper = mapper;
        _testSubjectRepository =  testSubjectRepository;
        _recordRepository = recordRepository;
    }

    public Guid CreateNewResearch(ResearchBm researchBm)
    {
        researchBm.Id = Guid.NewGuid();
        researchBm.Start = DateTime.Now;
        researchBm.Start = DateTime.SpecifyKind(researchBm.Start, DateTimeKind.Utc);
        _researchRepository.Add(_mapper.Map<Research>(researchBm));
        return researchBm.Id;
    }

    public Guid AddTestSubject(TestSubjectBm testSubjectBm)
    {
        testSubjectBm.Id = Guid.NewGuid();
        _testSubjectRepository.Add(_mapper.Map<TestSubject>(testSubjectBm));
        return testSubjectBm.Id;
    }

    public Guid AddRecord(RecordBm recordBm)
    {
        recordBm.Id = Guid.NewGuid();
        recordBm.Hash  = FileManager.SaveFile(recordBm.FileBytes).Result;
        recordBm.MetaFileSize = recordBm.FileBytes.Length;
        _recordRepository.Add(_mapper.Map<Record>(recordBm));
        return recordBm.Id;
    }

    public IEnumerable<ResearchBm> GetResearches(Guid userId)
    {
        var researches =  _researchRepository.GetAllById(userId);
        return _mapper.Map<IEnumerable<ResearchBm>>(researches);
    }

    public IEnumerable<TestSubjectBm> GetTestSubjects(Guid researchId)
    {
        var testSubjects =  _testSubjectRepository.GetAllById(researchId);
        return _mapper.Map<IEnumerable<TestSubjectBm>>(testSubjects);
    }

    public IEnumerable<RecordBm> GetRecords(Guid testSubjectId)
    {
        var records =  _recordRepository.GetAllById(testSubjectId);
        return _mapper.Map<IEnumerable<RecordBm>>(records);
    }
}
using AutoMapper;
using NeuroProject.BLL.BusinessModels;
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
        researchBm.ResearchId = Guid.NewGuid();
        _researchRepository.Add(_mapper.Map<Research>(researchBm));
        return researchBm.ResearchId;
    }

    public Guid AddTestSubject(TestSubjecBm testSubjecBm)
    {
        testSubjecBm.TestSubjectId = Guid.NewGuid();
        _testSubjectRepository.Add(_mapper.Map<TestSubject>(testSubjecBm));
        return testSubjecBm.TestSubjectId;
    }

    public Guid AddRecord(RecordBm recordBm)
    {
        recordBm.Id = Guid.NewGuid();
        _recordRepository.Add(_mapper.Map<Record>(recordBm));
        return recordBm.Id;
    }
}
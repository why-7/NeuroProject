using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NeuroProject.BLL.BusinessModels;
using NeuroProject.BLL.Services;
using NeuroProject.Web.Dto;
using NeuroProject.Web.Dto.Response;

namespace NeuroProject.Web.Controllers;

[ApiController]
[Route("api/researches")]
public class ResearchesController : Controller
{
    private readonly IResearchesService _researchesService;
    private readonly IMapper _mapper;
    
    public ResearchesController(IMapper mapper, IResearchesService researchesService )
    {
        _researchesService = researchesService;
        _mapper = mapper;
    }
    
    [Authorize]
    [HttpPost]
    public IActionResult CreateNewResearch([FromForm]CreateResearchDto dto)
    {
        var researchBm = _mapper.Map<ResearchBm>(dto);
        researchBm.AuthorId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        var id =  _researchesService.CreateNewResearch(researchBm);
        return Ok(id);
    }
    
    [Authorize]
    [HttpPost("add-test-subject")]
    public IActionResult AddTestSubject([FromForm]AddTestSubjectDto dto)
    {
        var id =  _researchesService.AddTestSubject(_mapper.Map<TestSubjectBm>(dto));
        return Ok(id);
    }
    
    [Authorize]
    [HttpPost("add-record")]
    public IActionResult AddRecord([FromForm]AddRecordDto dto)
    {
        var uploadedFileBytes = GetBytesOfFile(dto.FileRecord).Result;
        var bm = _mapper.Map<RecordBm>(dto);
        bm.FileBytes = uploadedFileBytes;
        var id =  _researchesService.AddRecord(bm);
        return Ok(id);
    } 

    [Authorize]
    [HttpGet("get-researches")]
    public IActionResult GetResearches()
    {
        var userId =  Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        var researches = _researchesService.GetResearches(userId);
        return Ok(_mapper.Map<IEnumerable<ResearchDto>>(researches));
    }
    
    [Authorize]
    [Route("get-test-subjects/{researchId}")]
    [HttpGet]
    public IActionResult GetTestSubjects(Guid researchId)
    {
        var testSubjects = _researchesService.GetTestSubjects(researchId);
        return Ok(_mapper.Map<IEnumerable<TestSubjectDto>>(testSubjects));
    }
    
    [Authorize]
    [Route("get-records/{testSubjectId}")]
    [HttpGet]
    public IActionResult GetRecords(Guid testSubjectId)
    {
        var records = _researchesService.GetRecords(testSubjectId);
        return Ok(_mapper.Map<IEnumerable<RecordDto>>(records));
    }
    
    private async Task<byte[]> GetBytesOfFile(IFormFile uploadedFile)
    {
        byte[] uploadedFileBytes = null;
    
        await using var memoryStream = new MemoryStream();
        await uploadedFile.CopyToAsync(memoryStream);
        uploadedFileBytes = memoryStream.ToArray();
    
        return uploadedFileBytes;
    }
}
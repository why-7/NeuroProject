using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NeuroProject.BLL.BusinessModels;
using NeuroProject.BLL.Services;
using NeuroProject.Web.Dto;

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
    
    [HttpPost]
    public IActionResult CreateNewResearch([FromForm]CreateResearchDto dto)
    {
        var researchBm = _mapper.Map<ResearchBm>(dto);
        researchBm.AuthorId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        var id =  _researchesService.CreateNewResearch(researchBm);
        return Ok(id);
    }
    
    [HttpPost("add-subject")]
    public IActionResult AddTestSubject([FromForm]AddTestSubjectDto dto)
    {
        var id =  _researchesService.AddTestSubject(_mapper.Map<TestSubjecBm>(dto));
        return Ok(id);
    }
    
    [HttpPost("add-record")]
    public IActionResult AddRecord([FromForm]AddRecordDto dto)
    {
        var id =  _researchesService.AddRecord(_mapper.Map<RecordBm>(dto));
        return Ok(id);
    }
    
    // private async Task<byte[]> GetBytesOfFile(IFormFile uploadedFile)
    // {
    //     byte[] uploadedFileBytes = null;
    //
    //     await using var memoryStream = new MemoryStream();
    //     await uploadedFile.CopyToAsync(memoryStream);
    //     uploadedFileBytes = memoryStream.ToArray();
    //
    //     return uploadedFileBytes;
    // }
}
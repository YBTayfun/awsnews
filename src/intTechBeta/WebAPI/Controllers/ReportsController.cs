using Application.Features.Reports.Commands.Create;
using Application.Features.Reports.Commands.Delete;
using Application.Features.Reports.Commands.Update;
using Application.Features.Reports.Queries.GetById;
using Application.Features.Reports.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Persistence.Contexts;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReportsController : BaseController
{
    private readonly BaseDbContext _context;
    private readonly IAiService _aiService;

    public ReportsController(BaseDbContext context,IAiService aiService)
    {
        _aiService = aiService;
        _context = context;
    }
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateReportCommand createReportCommand)
    {
        CreatedReportResponse response = await Mediator.Send(createReportCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateReportCommand updateReportCommand)
    {
        UpdatedReportResponse response = await Mediator.Send(updateReportCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedReportResponse response = await Mediator.Send(new DeleteReportCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdReportResponse response = await Mediator.Send(new GetByIdReportQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListReportQuery getListReportQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListReportListItemDto> response = await Mediator.Send(getListReportQuery);
        return Ok(response);
    }
    [HttpPost("UploadJsonFile")]
    public IActionResult UploadJsonFile(IFormFile file)
    {
        try
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Dosya yüklenemedi.");
            }

            using (var stream = new StreamReader(file.OpenReadStream()))
            {
                var json = stream.ReadToEnd();
                var reports = JsonConvert.DeserializeObject<List<Report>>(json);


                if (reports == null || !reports.Any())
                {
                    return BadRequest("Geçersiz veri.");
                }

                foreach (var report in reports)
                {
                    _context.Reports.Add(new Report
                    {
                        Id = Guid.NewGuid(),
                        Title = report.Title,
                        Link = report.Link,
                        Description = report.Description,
                        ReportDate = report.ReportDate
                    });
                }

                _context.SaveChanges();
            }

            return Ok("JSON dosyasındaki veriler başarıyla veritabanına eklendi.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Veri tabanına ekleme hatası: {ex.Message}");
        }
    }
    [HttpGet("processReportGpt")]
    public async Task<IActionResult> ProcessReportGpt()
    {
        try
        {   
            Report? report = _context.Reports.FirstOrDefault( c => c .Id.Equals(new  Guid("3841e613-c9d7-4bc2-a324-07d86df8fcab")));
            AiReport AiReport = await _aiService.GetAiReportAsync(report);

            _context.AiReports.Add(AiReport);
            _context.SaveChanges();
            return Ok("ReportGpt processing completed successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }
    [HttpGet("createDatasInDatabase")]
    public async Task<IActionResult> CreateDatasInDatabase()
    {
        System.Console.WriteLine("1");
        CreatedDatasInDatabaseResponse response = await Mediator.Send(new CreateDatasInDatabaseCommand());
                System.Console.WriteLine("2");


        return Ok(response);
    }
}
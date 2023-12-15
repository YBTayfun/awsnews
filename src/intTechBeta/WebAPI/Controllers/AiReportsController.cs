using Application.Features.AiReports.Commands.Create;
using Application.Features.AiReports.Commands.Delete;
using Application.Features.AiReports.Commands.Update;
using Application.Features.AiReports.Queries.GetById;
using Application.Features.AiReports.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AiReportsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateAiReportCommand createAiReportCommand)
    {
        CreatedAiReportResponse response = await Mediator.Send(createAiReportCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateAiReportCommand updateAiReportCommand)
    {
        UpdatedAiReportResponse response = await Mediator.Send(updateAiReportCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedAiReportResponse response = await Mediator.Send(new DeleteAiReportCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdAiReportResponse response = await Mediator.Send(new GetByIdAiReportQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListAiReportQuery getListAiReportQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListAiReportListItemDto> response = await Mediator.Send(getListAiReportQuery);
        return Ok(response);
    }
}
using Application.Features.AiReports.Commands.Create;
using Application.Features.AiReports.Commands.Delete;
using Application.Features.AiReports.Commands.Update;
using Application.Features.AiReports.Queries.GetById;
using Application.Features.AiReports.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.AiReports.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AiReport, CreateAiReportCommand>().ReverseMap();
        CreateMap<AiReport, CreatedAiReportResponse>().ReverseMap();
        CreateMap<AiReport, UpdateAiReportCommand>().ReverseMap();
        CreateMap<AiReport, UpdatedAiReportResponse>().ReverseMap();
        CreateMap<AiReport, DeleteAiReportCommand>().ReverseMap();
        CreateMap<AiReport, DeletedAiReportResponse>().ReverseMap();
        CreateMap<AiReport, GetByIdAiReportResponse>().ReverseMap();
        CreateMap<AiReport, GetListAiReportListItemDto>().ReverseMap();
        CreateMap<IPaginate<AiReport>, GetListResponse<GetListAiReportListItemDto>>().ReverseMap();
    }
}
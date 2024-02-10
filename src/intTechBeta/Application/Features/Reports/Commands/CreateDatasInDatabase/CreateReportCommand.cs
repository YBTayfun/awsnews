using Application.Features.Reports.Rules;
using Application.HangfireJobs.FireAndForgetJobs;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Newtonsoft.Json;

namespace Application.Features.Reports.Commands.Create;

public class CreateDatasInDatabaseCommand : IRequest<CreatedDatasInDatabaseResponse>
{

    public class CreateDatasInDatabaseCommandHandler : IRequestHandler<CreateDatasInDatabaseCommand, CreatedDatasInDatabaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IReportRepository _reportRepository;
        private readonly ReportBusinessRules _reportBusinessRules;

        public CreateDatasInDatabaseCommandHandler(IMapper mapper, IReportRepository reportRepository,
                                         ReportBusinessRules reportBusinessRules)
        {
            _mapper = mapper;
            _reportRepository = reportRepository;
            _reportBusinessRules = reportBusinessRules;
        }

        public async Task<CreatedDatasInDatabaseResponse> Handle(CreateDatasInDatabaseCommand request, CancellationToken cancellationToken)
        {

            string json = FireAndForgetJobs.FeedParser();

            string JsonDirectory = Path.Combine(json,"..","feed_data.json");
            System.Console.WriteLine("feed_data.json");

            string jsonData = File.ReadAllText(JsonDirectory);

            var reportDataList = JsonConvert.DeserializeObject<List<Report>>(jsonData);

            foreach (Report reportData in reportDataList)
            {
                Report report = new Report
                {
                    Id = Guid.NewGuid(),
                    Title = reportData.Title,
                    Link = reportData.Link,
                    Description = reportData.Description,
                    ReportDate = reportData.ReportDate
                };

                _reportRepository.Add(report);
            }

            CreatedDatasInDatabaseResponse response = new()
            {
                Message = "basarili bir sekilde olusturuldu"
            };
            return response;
        }
    }
}
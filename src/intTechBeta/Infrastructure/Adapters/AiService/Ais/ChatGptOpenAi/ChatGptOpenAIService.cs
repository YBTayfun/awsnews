using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OpenAI_API;

public class ChatGptOpenAIService : IAiService
{
    private readonly IConfiguration _configuration;
    public ChatGptOpenAIService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string? GetApiKey()
    {
        return _configuration.GetSection("ChatGptOpenAI:ApiKey").Value;
    }


    public async Task<string> GetCompletedAiReportAsync(Report report)
    {
        var openAiApiKey = GetApiKey();
        APIAuthentication aPIAuthentication = new APIAuthentication(openAiApiKey);
        OpenAIAPI api = new OpenAIAPI(aPIAuthentication);


        try
        {
            var chat = api.Chat.CreateConversation();
            chat.RequestParameters.MaxTokens = 500;
            chat.RequestParameters.Temperature = 0.2;
            chat.Model = "gpt-4";

            chat.AppendSystemMessage("You need to fetch information from the website provided in the link. The AdditionalDetail should be as really long as possible like 100 word .The information should only be returned in JSON format. Besides the JSON file, do not include any additional information, just return in JSON format. The format of the JSON file should be as follows:     string SideA string SideB   int CasualtiesA int CasualtiesB int CasualtiesAll int CasualtiesCivilian string Country string City string Region  string Source. If the searched value cannot be found, if information cannot be retrieved, fill it with a default value, meaning an empty string for string, 0 for integer, and an empty date value for date.. When filling in the names of SideA and SideB, you need to specify the parties involved in the incident. These could include entities like DAES,ISIS, PKK, Civilians, Public, Police, Security, Turkish Army, American Army, or individuals.When filling in the names of SideA and SideB, you need to specify the parties involved in the event. These could be, for instance, ISIS, PKK, Civilians, Public, Police, Security, Turkish Army, American Army, or individuals. However, while specifying the parties, avoid referring generally to a group, such as suspect, thief, or illegal immigrant. If the individuals are unidentified and there are no specific organizations, communities, or segments of the public mentioned in the news, write 'unknown individuals'.");

            chat.AppendUserInput(report.Link);

            string result = "";
            await foreach (var streamResultPart in chat.StreamResponseEnumerableFromChatbotAsync())
            {
                result += streamResultPart;
            }
            Console.WriteLine(result);
            return result;

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}"); return null;
        }
    }

    public async Task<AiReport> GetAiReportAsync(Report report)
    {

        string reportJson = await GetCompletedAiReportAsync(report);

        AiReportDto? reportDto = JsonConvert.DeserializeObject<AiReportDto>(reportJson);

        AiReport newReport = new AiReport
        {
            Id = Guid.NewGuid(),
            ReportId = reportDto.ReportId,
            SideA = reportDto.SideA,
            SideB = reportDto.SideB,
            CasualtiesA = reportDto.CasualtiesA,
            CasualtiesB = reportDto.CasualtiesB,
            CasualtiesAll = reportDto.CasualtiesAll,
            CasualtiesCivilian = reportDto.CasualtiesCivilian,
            Country = reportDto.Country,
            City = reportDto.City,
            Region = reportDto.Region,
            Source = reportDto.Source
        };
        return newReport;

    }



}
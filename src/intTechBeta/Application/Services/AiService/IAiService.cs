public interface IAiService
{
    public string? GetApiKey();
    public Task<AiReport> GetAiReportAsync(Report report);
    public Task<string> GetCompletedAiReportAsync(Report report);
}
namespace Application.HangfireJobs.FireAndForgetJobs
{
    public class FireAndForgetJobs
    {

        public static string FeedParser()
        {
            string json = Hangfire.BackgroundJob.Enqueue<MainJobs>(x => x.FeedParser());
            return json;

        }
    }
}
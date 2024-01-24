using Hangfire;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HangfireJobs.RecurringJobs;
public class RecurringJobs
{
    public static void FeedParser()
    {
        Hangfire.RecurringJob.AddOrUpdate<MainJobs>(recurringJobId:"FeedParser",
            x => x.FeedParser(), 
            Cron.Minutely());
        
    }
}
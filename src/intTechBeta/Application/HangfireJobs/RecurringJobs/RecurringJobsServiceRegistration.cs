using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.HangfireJobs.RecurringJobs;
public  class RecurringJobsServiceRegistration : BackgroundService
{
    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        RecurringJobs.FeedParser();
        return Task.CompletedTask;
    }
}
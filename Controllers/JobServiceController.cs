using Hangfire;
using Microsoft.AspNetCore.Mvc;

namespace HangFireExample.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobController:ControllerBase{
        private readonly IJobService _jobsService;
        private readonly IBackgroundJobClient _jobClient;
        private readonly IRecurringJobManager _recurringJobManager;

        public JobController(IJobService jobService,IBackgroundJobClient backgroundJobClient,IRecurringJobManager recurringJobManager)
        {
            _jobsService = jobService;
            _jobClient = backgroundJobClient;
            _recurringJobManager = recurringJobManager;
        }

        [HttpGet("FireAndForgetJob")]
        public ActionResult CreateFireAndForgetJob()
        {
            _jobClient.Enqueue(() => _jobsService.FireAndForget());

            return Ok();
        }

        [HttpGet("DelayedJob")]
        public ActionResult CreateDelayedJob()
        {
            _jobClient.Schedule(() => _jobsService.DelayedJob(), TimeSpan.FromSeconds(5));

            return Ok();
        }

        [HttpGet("ReccuringJob")]
        public ActionResult CreateReccuringJob()
        {
            _recurringJobManager.AddOrUpdate("jobId", () => _jobsService.ReccuringJob(), Cron.Minutely);

            return Ok();
        }

        [HttpGet("ContinuationJob")]
        public ActionResult CreateContinuationJob()
        {
            var parentJobId = _jobClient.Enqueue(() => _jobsService.FireAndForget());

            _jobClient.ContinueJobWith(parentJobId, () => _jobsService.Continutation());

            return Ok();
        }

        [HttpGet("BatchJob")]
        public ActionResult CreateBatchJob()
        {
            //var batchId = BatchJob.StartNew(batch => {
            //    batch.Enqueue(() => DownloadFileFromServer());
            //    batch.Enqueue(() => ProcessFile());
            //    batch.Enqueue(() => SaveResultsToDatabase());
            //});

            return Ok();
        }
}
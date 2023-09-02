namespace HangFireExample.JobService;

public class JobService : IJobService
{
    public void BatchJob()
    {
        Console.WriteLine("This is a Batch Job");
    }

    

    public void Continutation()
    {
        Console.WriteLine("This is a Continuation");
    }

    public void DelayedJob()
    {
        Console.WriteLine("This is a Delayed Job");
    }

    public void FireAndForget()
    {
        Console.WriteLine("This is a fire and forget job");
    }

    public void FireAndForgetJob()
    {
        Console.WriteLine("This is a Fire and Forget Job");
    }

    public void ReccuringJob()
    {
        Console.WriteLine("This is a Reccuring Job");
    }
}

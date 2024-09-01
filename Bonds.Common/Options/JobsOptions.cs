namespace Bonds.Common.Options
{
    public class JobsOptions
    {
        public Dictionary<string, JobOption> Settings { get; set; }
    }

    public class JobOption
    {
        public string Cron { get; set; }
    }
}

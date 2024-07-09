namespace Bonds.Core.Jobs
{
    public interface IJob
    {
        Task Execute();
    }
}

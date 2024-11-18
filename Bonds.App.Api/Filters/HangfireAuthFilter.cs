using Hangfire.Dashboard;

namespace Bonds.App.Api.Filters
{
    public class HangfireAuthFilter : IDashboardAuthorizationFilter

    {
        public bool Authorize(DashboardContext context)
        {
            return true;
        }
    }
}

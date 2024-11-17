namespace Bonds.Core.Helpers
{
    public static class DatesHelper
    {
        public static TimeZoneInfo MOSCOW = TimeZoneInfo.FindSystemTimeZoneById("Russian Standard Time");
        public static DateTime GetMscNow() => TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, MOSCOW);
    }
}

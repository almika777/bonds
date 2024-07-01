using Bonds.Common.Enums;

namespace Bonds.DataProvider.Entities
{
    public class TelegramUserEntity
    {
        public int Id { get; set; }
        public string TelegramId { get; set; }
        public UserNotifyPeriod NotifyPeriod { get; set; }
        public UserBondCriteriaEntity BondCriteria { get; set; }
        public DateTime LastNotification { get; set; }
    }

}

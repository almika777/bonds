﻿namespace Bonds.DataProvider.Entities
{
    public class UserBondCriteriaEntity
    {
        public List<string> IgnoreNames { get; set; }
        public double DayChanges { get; set; }
        public double MinCouponPercent { get; set; }
    }
}
using Bonds.Core.Results;
using System.Globalization;

namespace Bonds.Core.Helpers
{
    public static class MoexResponseDeserializer
    {
        public static BondInfo Deserialize(List<List<object>> response) => new()
        {
            SecId = response[0][2].ToString(),
            Isin = response[0][2].ToString(),
            Name = response[4][2].ToString(),
            ShortName = response[2][3].ToString(),
            IssueDate = DateTime.Parse(response[5][2].ToString()),
            MateDate = DateTime.Parse(response[6][2].ToString()),
            BuybackDate = DateTime.Parse(response[7][2].ToString()),
            CouponPercent = double.Parse(response[20][2].ToString(), CultureInfo.InvariantCulture),
            CouponValue = double.Parse(response[21][2].ToString(), CultureInfo.InvariantCulture),
            FaceValue = double.Parse(response[16][2].ToString(), CultureInfo.InvariantCulture),
            DaysToRedemption = int.Parse(response[14][2].ToString()),
            CouponFrequency = int.Parse(response[18][2].ToString()),
            CouponDate = DateTime.Parse(response[19][2].ToString())
        };

        /*
        public static BondQuotes Deserialize(List<List<object>> response) => new()
        {
            SecId = response[0][2].ToString(),
            Isin = response[0][2].ToString(),
            Name = response[4][2].ToString(),
            ShortName = response[2][3].ToString(),
            IssueDate = DateTime.Parse(response[5][2].ToString()),
            MateDate = DateTime.Parse(response[6][2].ToString()),
            BuybackDate = DateTime.Parse(response[7][2].ToString()),
            CouponPercent = double.Parse(response[20][2].ToString(), CultureInfo.InvariantCulture),
            CouponValue = double.Parse(response[21][2].ToString(), CultureInfo.InvariantCulture),
            FaceValue = double.Parse(response[16][2].ToString(), CultureInfo.InvariantCulture),
            DaysToRedemption = int.Parse(response[14][2].ToString()),
            CouponFrequency = int.Parse(response[18][2].ToString()),
            CouponDate = DateTime.Parse(response[19][2].ToString())
        };*/
    }
}

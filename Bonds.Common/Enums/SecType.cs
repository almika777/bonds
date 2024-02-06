namespace Bonds.Common.Enums
{
    public enum SecType
    {
        Stocks,                 //Акции обыкновенные
        StocksPriv,             //Акции привилегированные
        StocksRussian,          //Ценная бумага РФ
        StocksRussianMunicip,   //Ценные бумаги муниципальные и субъектов РФ
        OFZ,                    //Ценные бумаги ЦБ РФ
        Bonds,                  //Корпоративные облигации
        BondsMfo,               //Облигации МФО
        BondsBirzh,             //Биржевые облигации
        PifOpen,                //Паи открытых ПИФов
        PifInterval,            //Паи интервальных ПИФов
        PifClosed,              //Паи закрытых ПИФов
    }
}

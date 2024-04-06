using Bonds.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonds.Core.Jobs
{
    public class MoexTradesReader
    {
        private readonly IMoexHttpDataClient _moexHttpDataClient;

        public MoexTradesReader(IMoexHttpDataClient moexHttpDataClient)
        {
            _moexHttpDataClient = moexHttpDataClient;
        }

        public async Task Read()
        {
            var trades = await _moexHttpDataClient.GetBondsTrades("");
        }
    }
}

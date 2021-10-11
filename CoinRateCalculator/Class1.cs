using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoinRateCalculator
{

    public class iNFO
    {
        public int timestamp { get; set; }
        public float rate { get; set; }
    }


    public class QUERY
    {
        public string from { get; set; }
        public string to { get; set; }
        public int amount { get; set; }
    }

    public class RateResponse
    {
        [JsonProperty("success"]
        public bool Success { get; set; }
    }

}

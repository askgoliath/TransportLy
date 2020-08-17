using Newtonsoft.Json;

namespace TransportLy.DTO
{
    public class ShipOrderInfo
    {
        [JsonProperty("destination")]
        public string Destination { get; set; }
    }
}

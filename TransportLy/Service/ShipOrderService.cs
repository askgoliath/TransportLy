using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using TransportLy.DTO;

namespace TransportLy.Service
{
    public interface IShipOrderService
    {
        IEnumerable<ShipOrder> GetShipOrders();
    }

    public class ShipOrderService : JsonDataService, IShipOrderService
    {
        private static readonly string file = "coding-assigment-orders.json";

        public IEnumerable<ShipOrder> GetShipOrders()
        {
            string json = LoadJsonData(file);
            Dictionary<string, ShipOrderInfo> orders = JsonConvert.DeserializeObject<Dictionary<string, ShipOrderInfo>>(json);
            return orders.Select(a => new ShipOrder(a.Key, a.Value));
        }
    }
}

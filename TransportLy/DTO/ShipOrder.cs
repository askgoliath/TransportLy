namespace TransportLy.DTO
{
    public class ShipOrder
    {
        public ShipOrder(string orderNo, ShipOrderInfo info)
        {
            OrderNo = orderNo;
            Info = info;
        }

        public string OrderNo { get; set; }

        public ShipOrderInfo Info { get; set; }
    }
}

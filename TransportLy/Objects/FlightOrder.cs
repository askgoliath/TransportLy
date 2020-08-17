using System;
namespace TransportLy.Objects
{
    public class FlightOrder
    {
        public FlightOrder(string orderNo, Flight flight)
        {
            OrderNo = orderNo;
            Flight = flight;
        }

        public string OrderNo { get; protected set; }

        public Flight Flight { get; set; }

        public override string ToString()
        {
            var summary = $"order: {OrderNo}, ";

            summary += (Flight?.ToString() ?? "flightnumber: not scheduled");

            return summary;
        }
    }
}

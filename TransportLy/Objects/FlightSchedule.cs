using System;
namespace TransportLy.Objects
{
    public class FlightSchedule
    {
        public FlightSchedule()
        {
        }

        public int Day { get; set; }

        public DateTime Time { get; set; }

        public City DepartureCity { get; set; }

        public City ArrivalCity { get; set; } 
    }
}

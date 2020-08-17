using System;
using System.Text;

namespace TransportLy.Objects
{
    public class Flight
    {
        public Flight(int flightNo, FlightSchedule schedule)
        {
            FlightNo = flightNo;
            Schedule = schedule ?? new FlightSchedule();
        }

        public int FlightNo { get; }

        public int BoxCount { get; set; }

        public FlightSchedule Schedule { get; }

        public override string ToString()
        {
            return $"flightNumber: {FlightNo}, departure: {Schedule.DepartureCity?.Code}, arrival: {Schedule.ArrivalCity?.Code}, day: {Schedule.Day}";
        }
    }
}

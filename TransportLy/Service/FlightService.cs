using System;
using System.Collections.Generic;
using TransportLy.Objects;

namespace TransportLy.Service
{
    public interface IFlightService {
        List<Flight> GetFlights();
    }

    public class FlightService : IFlightService, IDataService
    {
        public FlightService()
        {
        }

        public List<Flight> GetFlights()
        {
            int flightNumber = 0;
            var flights = new List<Flight>();

            flights.AddRange(NewFlightDay(1, ref flightNumber));
            flights.AddRange(NewFlightDay(2, ref flightNumber));

            return flights;
        }

        private static Flight[] NewFlightDay(int day, ref int lastflightNo)
        {
            var flights = new Flight[]
            {
                new Flight(++lastflightNo, new FlightSchedule()
                {
                    DepartureCity = new City("YUL", "Montreal"),
                    ArrivalCity = new City("YYZ", "Toronto"),
                    Day = day
                }),


                new Flight(++lastflightNo, new FlightSchedule()
                {
                    DepartureCity = new City("YUL", "Montreal"),
                    ArrivalCity = new City("YYC", "Calgary"),
                    Day = day
                }),

                new Flight(++lastflightNo, new FlightSchedule()
                {
                    DepartureCity = new City("YUL", "Montreal"),
                    ArrivalCity = new City("YVR", "Vancouver"),
                    Day = day
                })
            };

            return flights;
        }
    }
}

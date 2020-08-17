using System;
using System.Collections.Generic;
using TransportLy.Logic;
using TransportLy.Objects;
using TransportLy.Service;

namespace TransportLy
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IFlightService flightService = new FlightService();

                List<Flight> flights = flightService.GetFlights();

                Console.WriteLine("\nFlight Schedule : \n");
                flights.ForEach(Console.WriteLine);

                ISchedulerLogic scheduler = new SchedulerLogic(new ShipOrderService());

                List<FlightOrder> flightOrders = scheduler.ScheduleFlightOrders(flights);

                Console.WriteLine("\n Orders Flight Schedule : \n");
                flightOrders.ForEach(Console.WriteLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred during execution: ");
                Console.WriteLine(ex);
            }

            Console.ReadKey();
        }

    }
}

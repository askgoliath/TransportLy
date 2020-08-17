using System;
using System.Collections.Generic;
using System.Linq;
using TransportLy.DTO;
using TransportLy.Objects;
using TransportLy.Service;

namespace TransportLy.Logic
{
    public interface ISchedulerLogic
    {
        List<FlightOrder> ScheduleFlightOrders(IEnumerable<Flight> flights);
    }

    public class SchedulerLogic : ISchedulerLogic
    {
        private readonly IShipOrderService shipOrderService;
        public static int FlightOrderCapacity = 20;

        public SchedulerLogic(IShipOrderService service)
        {
            shipOrderService = service;
        }

        public List<FlightOrder> ScheduleFlightOrders(IEnumerable<Flight> flights)
        {
            var orders = shipOrderService.GetShipOrders();

            List<FlightOrder> flightOrders = AssignFlightToOrders(flights, orders);

            return flightOrders;
        }

        private List<FlightOrder> AssignFlightToOrders(IEnumerable<Flight> flights, IEnumerable<ShipOrder> orders)
        {
            var flightOrders = new List<FlightOrder>();

            foreach (var order in orders)
            {
                var nextFlight = GetNextAvailableFlightForOrder(order, flights);

                flightOrders.Add(new FlightOrder(order.OrderNo, nextFlight));

                if (nextFlight != null) nextFlight.BoxCount++;
            }

            return flightOrders;
        }

        private Flight GetNextAvailableFlightForOrder(ShipOrder order, IEnumerable<Flight> flights)
        {
            return flights.Where(a =>
                string.Equals(a.Schedule.ArrivalCity.Code, order.Info.Destination, StringComparison.InvariantCultureIgnoreCase)
                && a.BoxCount < FlightOrderCapacity
            ).OrderBy(a => a.Schedule.Day).FirstOrDefault();
        }
    }
}

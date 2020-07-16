using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zadatak_1
{
    class Program
    {
        public static Random r = new Random();

        static void Main(string[] args)
        {
            string[] Direction = new string[2];
            Direction[0] = "North";
            Direction[1] = "South";

            List<Vehicle> Vehicles = new List<Vehicle>();

            for (int i = 1; i <= r.Next(1, 16); i++)
            {
                Vehicle v = new Vehicle(Direction[r.Next(0, 2)]);
                Vehicles.Add(v);
                AllVehicles(v, i);
            }

            foreach (Vehicle v in Vehicles)
            {
                Thread t = new Thread();
            }
            Console.ReadLine();
        }

        public static void

        public delegate void Notification();

        public static event Notification OnNotification;

        public static void AllVehicles(Vehicle v, int i)
        {
            OnNotification = () =>
            {
                Console.WriteLine("Vehicle {0}, Direction: {1}", i, v.Direction);
            };
            OnNotification.Invoke();
        }
    }
}

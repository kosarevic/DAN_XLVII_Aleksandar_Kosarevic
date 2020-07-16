using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Zadatak_1
{
    /// <summary>
    /// Application simulates one-way diriction bridge.
    /// </summary>
    class Program
    {
        //Random number generator variable.
        public static Random r = new Random();
        //Static numerals added for logical calculation of remaining vehicles in each direction.
        public static int north = 0;
        public static int south = 0;

        static void Main(string[] args)
        {
            //Stopwatch calculates application lifetime.
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            //Directions predetermined by placment in an array.
            string[] Direction = new string[2];
            Direction[0] = "North";
            Direction[1] = "South";
            //All wehicles are created and stored in a list.
            List<Vehicle> Vehicles = new List<Vehicle>();
            
            for (int i = 1; i <= r.Next(1, 16); i++)
            {
                Vehicle v = new Vehicle(i, Direction[r.Next(0, 2)]);
                Vehicles.Add(v);
                AllVehicles(v);
            }

            Console.WriteLine();
            //Logic of whole application is realised below.
            foreach (Vehicle v in Vehicles)
            {
                //If conditions match, vehicles heading in north direction will be going all at once.
                if (v.Direction == "North" && south == 0)
                {
                    //Code repeats as many times as consecutive vehicles are having "North" direction.
                    ++north;
                    south = 0;
                    Thread t = new Thread(() => BridgeNorth(v));
                    t.Start();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Vehicle {0}, Direction: {1}, has started crossing the bridge.", v.Id, v.Direction);
                    //Loop skips rest of the code if vehicle direction is north bound.
                    continue;
                }
                //Vehicles bound for "South" direction will be waiting for previous direction to complete.
                if (north != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Vehicle {0}, Direction: {1}, is waitng to cross the bridge.", v.Id, v.Direction);
                }
                //Untill all vehicles complete jurney in north direction, application freezes(waits) at this point.
                while (north != 0)
                {
                }

                //If conditions match, vehicles heading in sorth direction will be going all at once.
                if (v.Direction == "South" && north == 0)
                {
                    //Code repeats as many times as consecutive vehicles are having "Sorth" direction.
                    ++south;
                    north = 0;
                    Thread t = new Thread(() => BridgeSouth(v));
                    t.Start();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Vehicle {0}, Direction: {1}, has started crossing the bridge.", v.Id, v.Direction);
                    //Loop skips rest of the code if vehicle direction is south bound.
                    continue;
                }
                //Vehicles bound for "North" direction will be waiting for previous direction to complete.
                if (south != 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Vehicle {0}, Direction: {1}, is waitng to cross the bridge.", v.Id, v.Direction);
                }
                //Untill all vehicles complete jurney in south direction, application freezes(waits) at this point.
                while (south != 0)
                {
                }

                if (v.Direction == "North" && south == 0)
                {
                    //Code repeats as many times as consecutive vehicles are having "North" direction.
                    ++north;
                    south = 0;
                    Thread t = new Thread(() => BridgeNorth(v));
                    t.Start();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Vehicle {0}, Direction: {1}, has started crossing the bridge.", v.Id, v.Direction);
                    //Loop skips rest of the code if vehicle direction is north bound.
                    continue;
                }
            }
            //Time spent using application is displayed below.
            Thread.Sleep(550);
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Applicaiton runtime: " + stopWatch.ElapsedMilliseconds + " ms");
            Console.ReadLine();
        }
        /// <summary>
        /// Method invoked when vehicles are North bound.
        /// </summary>
        /// <param name="v"></param>
        public static void BridgeNorth(Vehicle v)
        {
            Thread.Sleep(500);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Vehicle {0}, Direction: {1}, has crossed the bridge.", v.Id, v.Direction);
            --north;
        }
        /// <summary>
        /// Method invoked when vehicles are South bound.
        /// </summary>
        /// <param name="v"></param>
        public static void BridgeSouth(Vehicle v)
        {
            Thread.Sleep(500);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Vehicle {0}, Direction: {1}, has crossed the bridge.", v.Id, v.Direction);
            --south;
        }
        /// <summary>
        /// Delegate and Event for displaying vehicle creation process.
        /// </summary>
        public delegate void Notification();

        public static event Notification OnNotification;

        public static void AllVehicles(Vehicle v)
        {
            OnNotification = () =>
            {
                Console.WriteLine("Vehicle {0}, Direction: {1}, has been created.", v.Id, v.Direction);
            };
            OnNotification.Invoke();
        }
    }
}

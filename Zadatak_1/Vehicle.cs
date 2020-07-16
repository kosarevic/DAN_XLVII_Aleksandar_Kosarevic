using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak_1
{
    class Vehicle
    {
        public int Id { get; set; }
        public string Direction { get; set; }

        public Vehicle()
        {
        }

        public Vehicle(int id, string direction)
        {
            Id = id;
            Direction = direction;
        }
    }
}

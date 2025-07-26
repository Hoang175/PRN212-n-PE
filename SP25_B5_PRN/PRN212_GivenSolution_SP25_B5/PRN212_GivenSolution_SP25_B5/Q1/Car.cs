using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    public class Car : Vehicle
    {
        public Car()
        {
        }

        public Car(string name, int speed) : base(name, speed)
        {
        }

        public override string DescribeMovement()
        {
            return $"{Name} is driving at {Speed} km/h";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
   public class Bicycle : Vehicle
    {
        public Bicycle()
        {
        }

        public Bicycle(string name, int speed) : base(name, speed)
        {
        }

        public override string DescribeMovement()
        {
            return $"{Name} is pedating at {Speed} km/h";
        }
    }
}

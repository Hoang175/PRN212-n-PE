using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q1
{
    public abstract class Vehicle
    {
        private string name;
        private int speed;

        protected Vehicle(string name, int speed)
        {
            this.name = name;
            this.speed = speed;
        }

        protected Vehicle() { }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Speed
        {
            get { return speed; }
            set { speed = value; }
        }

        public abstract string DescribeMovement();
    }
}

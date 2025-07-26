namespace Q1
{

    public delegate int SpeedAdjuster(int currentSpeed);

    public static class SpeedCalculator
    {
        public static int IncreaseSpeed(int currentSpeed)
        {
            return (currentSpeed + 10);
        }

        public static int DecreaseSpeed(int currentSpeed)
        {
            return (currentSpeed - 5);
        }
    }

    public class Program
    {
        static void Main()
        {
            Car car = new Car("Toyota", 100);
            Bicycle bicycle = new Bicycle("Phoenix", 20);

            SpeedAdjuster adjuster = SpeedCalculator.IncreaseSpeed;
            car.Speed = adjuster(car.Speed);
            Console.WriteLine(car.DescribeMovement());

            adjuster = SpeedCalculator.DecreaseSpeed;
            bicycle.Speed = adjuster(bicycle.Speed);
            Console.WriteLine(bicycle.DescribeMovement());
        }
    }
}

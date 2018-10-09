using System;
using System.Collections.Generic;

namespace Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());
            Queue<string> cars = new Queue<string>();
            string input = Console.ReadLine();
            int passedCars = 0;
            while (input != "END")
            {
                if (input!="green")
                {
                    cars.Enqueue(input);
                    input = Console.ReadLine();
                    continue;
                }
                var currentGreenLight= greenLightDuration;
                var currentCar = "";
                var outputCar = "";
                while (cars.Count > 0 && currentGreenLight> 0)
                {
                    currentCar = cars.Dequeue();
                    outputCar = currentCar;
                    currentGreenLight -= currentCar.Length;
                    if (currentGreenLight >=0)
                    {
                        passedCars++;
                        continue;
                    }
                    currentCar = currentCar.Remove(0, (currentCar.Length - currentGreenLight*-1));
                    currentGreenLight += freeWindowDuration;
                    if (currentGreenLight >=0)
                    {
                        passedCars++;
                        break;
                    }
                    currentCar = currentCar.Remove(0, (currentCar.Length - currentGreenLight*-1));
                    Console.WriteLine($"A crash happened!");
                    Console.WriteLine($"{outputCar} was hit at {currentCar[0]}.");
                    return;
                }
                input = Console.ReadLine();
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{passedCars} total cars passed the crossroads.");
        }
    }
}

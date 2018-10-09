using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TicketTrouble
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<string> seats = new List<string>();

            string squarePattern = @"\[[^\]]*{([A-Z]{3} [A-Z]{2})}.*?{([A-Z]{1}[0-9]{1,2})}[^[]*\]";
            string curlyPattern = @"\{[^}]*\[([A-Z]{3} [A-Z]{2})\].*?\[([A-Z]{1}[0-9]{1,2})\][^{]*}";

            var destination = Console.ReadLine();
            var input = Console.ReadLine();

            MatchCollection squareCollection = Regex.Matches(input, squarePattern);
            MatchCollection curlyCollection = Regex.Matches(input, curlyPattern);

            AddSeats(seats, destination, squareCollection);
            AddSeats(seats, destination, curlyCollection);

            if (seats.Count == 2)
            {
                Console.WriteLine($"You are traveling to {destination} on seats {seats[0]} and {seats[1]}.");
            }
            else
            {
                for (int i = 0; i < seats.Count; i++)
                {
                    for (int j = i+1; j < seats.Count; j++)
                    {
                        var first = seats[i].Substring(1);
                        var sec = seats[j].Substring(1);

                        if (first == sec)
                        {
                            Console.WriteLine($"You are traveling to {destination} on seats {seats[i]} and {seats[j]}.");
                            return;
                        }

                    }
                }
            }
            
        }

        private static void AddSeats(List<string> seats, string destination, MatchCollection collectiion)
        {
            foreach (Match match in collectiion)
            {
                if (match.Groups[1].Value.Contains(destination))
                {
                    seats.Add(match.Groups[2].Value);
                }
            }
        }
    }
}

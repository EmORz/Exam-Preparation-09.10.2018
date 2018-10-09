using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace MovieTime
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var movieList = new Dictionary<string, Dictionary<string, TimeSpan>>();
            var favoriteGenre = Console.ReadLine();
            var favoriteDuration = Console.ReadLine();

            string input = Console.ReadLine();

            while (input != "POPCORN!")
            {
                var tokens = input.Split("|");

                var filmName = tokens[0];
                var genre = tokens[1];
                var duration = tokens[2];

                TimeSpan time = TimeSpan.Parse(duration, CultureInfo.InvariantCulture);

                if (!movieList.ContainsKey(genre))
                {
                    movieList.Add(genre, new Dictionary<string, TimeSpan>());
                }
                if (!movieList[genre].ContainsKey(filmName))
                {
                    movieList[genre].Add(filmName, time);
                }

                input = Console.ReadLine();
            }
            movieList[favoriteGenre] = movieList[favoriteGenre]
                .OrderBy(x => favoriteDuration == "Short" ? x.Value : -x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, y => y.Value);

            foreach (var item in movieList[favoriteGenre])
            {
                Console.WriteLine(item.Key);
                var wifeCommand = Console.ReadLine();

                if (wifeCommand == "Yes")
                {
                    var totalSeconds = movieList.Values.Sum(x => x.Sum(s => s.Value.TotalSeconds));
                    string timeSpan = TimeSpan.FromSeconds(totalSeconds).ToString(@"hh\:mm\:ss");

                    Console.WriteLine($"We're watching {item.Key} - {item.Value}");
                    Console.WriteLine($"Total Playlist Duration: {timeSpan}");

                    return;
                }

            }
        }
    }
}

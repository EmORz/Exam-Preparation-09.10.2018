namespace P04_Dictionary
{
	using System;
	using System.Collections.Generic;
	using System.Globalization;
	using System.Linq;

	class Program
    {
		private const string TimeFormat = @"hh\:mm\:ss";

		static void Main(string[] args)
        {
			var movies = new Dictionary<string, List<KeyValuePair<string, TimeSpan>>>();

			string favouriteGenre = Console.ReadLine();
			string length = Console.ReadLine();

			string inputLine;
			while ((inputLine = Console.ReadLine()) != "POPCORN!")
			{
				string[] tokens = inputLine.Split('|');
				string genre = tokens[1];
				string movieName = tokens[0];
				string movieDurationString = tokens[2];

				if (!movies.ContainsKey(genre))
				{
					movies[genre] = new List<KeyValuePair<string, TimeSpan>>();
				}

				TimeSpan movieDuration = TimeSpan.ParseExact(tokens[2], TimeFormat, CultureInfo.InvariantCulture);

				var movie = new KeyValuePair<string, TimeSpan>(movieName, movieDuration);
				movies[genre].Add(movie);
			}

			bool prefersShortMovies = length == "Short";
			var potentialMovies = movies[favouriteGenre]
				.OrderBy(p => prefersShortMovies ? p.Value : -p.Value)
				.ThenBy(p => p.Key)
				.ToArray();

			int index = -1;
			string reaction = "No";
			while (reaction != "Yes")
			{
				index++;
				Console.WriteLine(potentialMovies[index].Key);

				reaction = Console.ReadLine();
			}

			string chosenMovie = potentialMovies[index].Key;
			string chosenMovieDuration = potentialMovies[index].Value.ToString(TimeFormat, CultureInfo.InvariantCulture);
			Console.WriteLine($"We're watching {chosenMovie} - {chosenMovieDuration}");

			long totalPlaylistTicks = movies.Sum(genre => genre.Value.Sum(movie => movie.Value.Ticks));
			TimeSpan totalTimeSpan = new TimeSpan(totalPlaylistTicks);
			string totalPlaylistDuration = totalTimeSpan.ToString(TimeFormat, CultureInfo.InvariantCulture);
			Console.WriteLine($"Total Playlist Duration: {totalPlaylistDuration}");
		}
    }
}

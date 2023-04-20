using System;
using System.IO;
using System.Linq;
using CharGenerator.Helpers;

namespace CharGenerator
{
	internal static class Program
	{
		private const string OutDir = @".\out";
		private static readonly string Task1File = Path.Combine(OutDir, "task1.txt");
		private static readonly string Task2File = Path.Combine(OutDir, "task2.txt");
		private static readonly string Task3File = Path.Combine(OutDir, "task3.txt");

		private static readonly IRandom Random = new Helpers.Random();

		private static void Main()
		{
			Directory.CreateDirectory(OutDir);

			Task1();
			Task2();
			Task3();
		}

		private static void Task1()
		{
			var alphabet = File
				.ReadAllText(@".\assets\alphabet.txt")
				.TrimEnd(Environment.NewLine.ToCharArray())
				.ToCharArray();

			var frequencyMatrix = File
				.ReadAllText(@".\assets\bigram_frequency_table.txt")
				.TrimEnd(Environment.NewLine.ToCharArray())
				.Split(new[] {"\r\n", "\n"}, StringSplitOptions.None)
				.Select(row => row
					.Split(' ')
					.Select(int.Parse)
					.ToArray())
				.ToArray();

			var generator = new BigramBasedTextGenerator(Random, alphabet, frequencyMatrix);
			File.WriteAllText(Task1File, generator.GenerateText(1200, 'я'));

		}

		private static void Task2()
		{
			var rows = File
				.ReadAllText(@".\assets\word_frequency_table.txt")
				.TrimEnd(Environment.NewLine.ToCharArray())
				.Split(new[] {"\r\n", "\n"}, StringSplitOptions.None)
				.Select(row =>
				{
					var split = row.Split(',');
					return (split[0], int.Parse(split[1]));
				})
				.ToArray();

			var words = rows.Select(row => row.Item1).ToArray();
			var weights = rows.Select(row => row.Item2).ToArray();

			var generator = new FrequencyBasedTextGenerator(Random, words, weights);
			File.WriteAllText(Task2File, generator.GenerateText(1000));
		}

		private static void Task3()
		{
			var rows = File
				.ReadAllText(@".\assets\word_pair_frequency_table.txt")
				.TrimEnd(Environment.NewLine.ToCharArray())
				.Split(new[] {"\r\n", "\n"}, StringSplitOptions.None)
				.Select(row =>
				{
					var split = row.Split(',');
					return (split[0], int.Parse(split[1]));
				})
				.ToArray();

			var pairs = rows.Select(row => row.Item1).ToArray();
			var weights = rows.Select(row => row.Item2).ToArray();

			var generator = new FrequencyBasedTextGenerator(Random, pairs, weights);
			File.WriteAllText(Task3File, generator.GenerateText(500));

		}
	}
}

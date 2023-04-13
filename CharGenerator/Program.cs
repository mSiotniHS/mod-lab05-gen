using System;
using System.IO;
using System.Linq;

namespace CharGenerator
{
	internal static class Program
	{
		private static void Main()
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
					.Select(double.Parse)
					.ToArray())
				.ToArray();

			var generator = new BigramBasedTextGenerator(alphabet, frequencyMatrix, 'а');

			for (var i = 0; i < 1000; i++)
			{
				Console.Write(generator.Next());
			}
		}
	}
}

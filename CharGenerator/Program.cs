using System;
using System.IO;
using System.Linq;

namespace CharGenerator
{
	internal static class Program
	{
		private const string OutDir = @".\out";
		private static readonly string Task1File = Path.Combine(OutDir, "task1.txt");

		private static void Main()
		{
			Directory.CreateDirectory(OutDir);

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

			var generator = new BigramBasedTextGenerator(alphabet, frequencyMatrix);
			File.WriteAllText(Task1File, generator.GenerateText(1200, 'б'));
		}
	}
}

using System;
using System.Linq;
using System.Text;
using CharGenerator.Helpers;

namespace CharGenerator
{
	public sealed class BigramBasedTextGenerator
	{
		private readonly char[] _alphabet;
		private readonly int[][] _frequencyMatrix;
		private readonly IRandom _random;

		public BigramBasedTextGenerator(IRandom random, char[] alphabet, int[][] frequencyMatrix)
		{
			if (alphabet.Length != frequencyMatrix.Length)
			{
				throw new ArgumentException(
					"alphabet and frequencyMatrix's row counts are different, but should be equal",
					nameof(frequencyMatrix));
			}

			var columnCounts = frequencyMatrix.Select(row => row.Length).ToArray();
			if (columnCounts.Distinct().Count() != 1)
			{
				throw new ArgumentException(
					"frequencyMatrix's columns are of inconsistent sizes",
					nameof(frequencyMatrix));
			}

			if (columnCounts[0] != alphabet.Length)
			{
				throw new ArgumentException(
					"alphabet and frequencyMatrix's column counts are different, but should be equal",
					nameof(frequencyMatrix));
			}

			_alphabet = alphabet;
			_frequencyMatrix = frequencyMatrix;
			_random = random;
		}

		private char NextCharacter(char previousLetter) =>
			Roulette.Spin(_random, _alphabet, _frequencyMatrix[Array.IndexOf(_alphabet, previousLetter)]);

		public string GenerateText(uint length, char firstLetter)
		{
			var builder = new StringBuilder(firstLetter.ToString());
			var previousLetter = firstLetter;

			for (var i = 0; i < length - 1; i++)
			{
				previousLetter = NextCharacter(previousLetter);
				builder.Append(previousLetter);
			}

			return builder.ToString();
		}
	}
}

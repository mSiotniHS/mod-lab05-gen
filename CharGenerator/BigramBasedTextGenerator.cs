﻿using System;
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

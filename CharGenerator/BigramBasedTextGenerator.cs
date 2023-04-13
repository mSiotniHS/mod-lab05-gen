using System;

namespace CharGenerator
{
	public sealed class BigramBasedTextGenerator
	{
		private readonly char[] _alphabet;
		private readonly double[][] _frequencyMatrix;

		private int _previousIdx;

		public BigramBasedTextGenerator(char[] alphabet, double[][] frequencyMatrix, char firstLetter)
		{
			_alphabet = alphabet;
			_frequencyMatrix = frequencyMatrix;
			_previousIdx = Array.IndexOf(_alphabet, firstLetter) switch
			{
				-1 => throw new Exception("Символ не из данного алфавита"),
				var value => value
			};
		}

		public char Next() =>
			Roulette.Spin(_alphabet, _frequencyMatrix[_previousIdx], out _previousIdx);
	}
}

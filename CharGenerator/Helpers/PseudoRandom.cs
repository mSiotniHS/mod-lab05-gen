namespace CharGenerator.Helpers
{
	public sealed class PseudoRandom : IRandom
	{
		private readonly double[] _values;
		private int _currentValueIdx;

		public PseudoRandom(double[] values)
		{
			_values = values;
			_currentValueIdx = 0;
		}

		public double NextDouble() => _values[_currentValueIdx++];
	}
}

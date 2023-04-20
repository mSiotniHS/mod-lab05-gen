namespace CharGenerator.Helpers
{
	public sealed class Random : IRandom
	{
		private static readonly System.Random Rng = new System.Random();

		public double NextDouble() => Rng.NextDouble();
	}
}

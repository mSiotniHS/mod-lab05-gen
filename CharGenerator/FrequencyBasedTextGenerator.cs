using System.Text;
using CharGenerator.Helpers;

namespace CharGenerator
{
	public sealed class FrequencyBasedTextGenerator
	{
		private readonly string[] _items;
		private readonly int[] _weights;
		private readonly IRandom _random;

		public FrequencyBasedTextGenerator(IRandom random, string[] items, int[] weights)
		{
			_items = items;
			_weights = weights;
			_random = random;
		}

		public string GenerateText(uint itemCount)
		{
			var builder = new StringBuilder();

			for (var i = 0u; i < itemCount; i++)
			{
				var nextWord = Roulette.Spin(_random, _items, _weights);
				builder.Append(nextWord);

				if (i != itemCount - 1)
				{
					builder.Append(' ');
				}
			}

			return builder.ToString();
		}
	}
}

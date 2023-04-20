using System.Text;

namespace CharGenerator
{
	public sealed class FrequencyBasedTextGenerator
	{
		private readonly string[] _items;
		private readonly int[] _weights;

		public FrequencyBasedTextGenerator(string[] items, int[] weights)
		{
			_items = items;
			_weights = weights;
		}

		public string GenerateText(uint itemCount)
		{
			var builder = new StringBuilder();

			for (var i = 0u; i < itemCount; i++)
			{
				var nextWord = Roulette.Spin(_items, _weights);
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

using System;
using System.Collections.Generic;
using System.Linq;
using CharGenerator.Helpers;

namespace CharGenerator
{
	public static class Roulette
	{
		public static T Spin<T>(IRandom random, IList<T> items, IList<int> weights, out int idx)
		{
			if (items.Count != weights.Count)
			{
				throw new ArgumentException("Количества item-ов и весов должны совпадать");
			}

			var totalWeight = weights.Sum();

			var randomNum = random.NextDouble() * totalWeight;
			var currentSector = 0.0;

			for (var i = 0; i < items.Count; i++)
			{
				currentSector += weights[i];
				if (randomNum <= currentSector)
				{
					idx = i;
					return items[i];
				}
			}

			throw new Exception("Случайное число оказалось вне отрезка");
		}

		public static T Spin<T>(IRandom random, IList<T> items, IList<int> weights) =>
			Spin(random, items, weights, out _);
	}
}

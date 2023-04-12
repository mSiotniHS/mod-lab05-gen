using System;
using System.Collections.Generic;
using System.Linq;

namespace CharGenerator
{
	public static class Roulette
	{
		private static readonly Random Random = new Random();

		public static T Spin<T>(IList<T> items, IList<double> weights, out int idx)
		{
			if (items.Count != weights.Count)
			{
				throw new ArgumentException("Количества item-ов и весов должны совпадать");
			}

			var totalWeight = weights.Sum();

			var randomNum = Random.NextDouble() * totalWeight;
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

		public static T Spin<T>(IList<T> items, IList<double> weights) => Spin(items, weights, out _);
	}
}

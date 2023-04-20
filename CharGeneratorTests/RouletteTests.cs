using System;
using CharGenerator;
using CharGenerator.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CharGeneratorTests
{
	[TestClass]
	public class RouletteTests
	{
		[TestClass]
		public class Spin
		{
			[TestMethod]
			public void ReturnsCorrectItem()
			{
				var items = new[] {"apple", "melon", "berry"};
				var weights = new[] {3, 1, 2};

				IRandom random = new PseudoRandom(new[] { 1.0 / 6, 3.5 / 6, 5.0 / 6 });

				Assert.AreEqual("apple", Roulette.Spin(random, items, weights));
				Assert.AreEqual("melon", Roulette.Spin(random, items, weights));
				Assert.AreEqual("berry", Roulette.Spin(random, items, weights));
			}

			[TestMethod]
			public void ThrowsIfItemAndWeightCountsDoesNotMatchUp()
			{
				var items = new[] {1};
				var weights = new[] {1, 2};

				Assert.ThrowsException<ArgumentException>(
					() => Roulette.Spin(new CharGenerator.Helpers.Random(), items, weights));
			}

			[TestMethod]
			public void ThrowsIfRandomValueWentOutOfBounds()
			{
				var items = new[] {1, 2};
				var weights = new[] {1, 2};

				IRandom random = new PseudoRandom(new[] { 2.0 });

				Assert.ThrowsException<Exception>(() => Roulette.Spin(random, items, weights));
			}
		}
	}
}

using System;
using CharGenerator;
using CharGenerator.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CharGeneratorTests
{
	[TestClass]
	public class FrequencyBasedTextGeneratorTests
	{
		[TestClass]
		public class GenerateText
		{
			[TestMethod]
			public void GeneratesExpectedText()
			{
				var items = new[] {"yoda", "am", "i"};
				var weights = new[] {3, 1, 2};
				var random = new PseudoRandom(new[] { 5.0 / 6, 3.5 / 6, 1.0 / 6 });

				var generator = new FrequencyBasedTextGenerator(random, items, weights);
				var actual = generator.GenerateText(3);

				Assert.AreEqual("i am yoda", actual);
			}
		}

		[TestClass]
		public class Ctor
		{
			[TestMethod]
			public void ThrowsIfItemAndWeightLengthsAreDifferent()
			{
				var items = new[] {"hi"};
				var weights = new[] {1, 2};

				Assert.ThrowsException<ArgumentException>(
					() => new FrequencyBasedTextGenerator(new CharGenerator.Helpers.Random(), items, weights));
			}
		}
	}
}

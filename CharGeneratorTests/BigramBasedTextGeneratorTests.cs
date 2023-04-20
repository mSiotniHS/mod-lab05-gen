using System;
using CharGenerator;
using CharGenerator.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CharGeneratorTests
{
	[TestClass]
	public class BigramBasedTextGeneratorTests
	{
		[TestClass]
		public class GenerateText
		{
			[TestMethod]
			public void GeneratesExpectedText()
			{
				var alphabet = new[] { 'a', 'b', 'c' };
				var frequencyMatrix = new[]
				{
					new[] { 1, 3, 4 },
					new[] { 4, 0, 1 },
					new[] { 3, 1, 2 }
				};

				var random = new PseudoRandom(new[] { 5.0 / 8, 2.0 / 6, 3.0 / 8, 1.0 / 5 });

				var generator = new BigramBasedTextGenerator(random, alphabet, frequencyMatrix);
				var actual = generator.GenerateText(5, 'a');

				Assert.AreEqual("acaba", actual);
			}
		}

		[TestClass]
		public class Ctor
		{
			[TestMethod]
			public void ThrowsIfRowCountDiffersWithAlphabetSize()
			{
				var alphabet = new[] {'a', 'b'};
				var frequencyMatrix = new[]
				{
					new[] { 1, 3 },
					new[] { 4, 0 },
					new[] { 3, 1 }
				};

				Assert.ThrowsException<ArgumentException>(
					() => new BigramBasedTextGenerator(new CharGenerator.Helpers.Random(), alphabet, frequencyMatrix));
			}

			[TestMethod]
			public void ThrowsIfColumnsAreOfInconsistentSizes()
			{
				var alphabet = new[] {'a', 'b'};
				var frequencyMatrix = new[]
				{
					new[] { 1, 3 },
					new[] { 4, 0, 3 }
				};

				Assert.ThrowsException<ArgumentException>(
					() => new BigramBasedTextGenerator(new CharGenerator.Helpers.Random(), alphabet, frequencyMatrix));
			}

			[TestMethod]
			public void ThrowsIfColumnCountDiffersWithAlphabetSize()
			{
				var alphabet = new[] {'a', 'b'};
				var frequencyMatrix = new[]
				{
					new[] { 1, 3, 2 },
					new[] { 4, 0, 3 }
				};

				Assert.ThrowsException<ArgumentException>(
					() => new BigramBasedTextGenerator(new CharGenerator.Helpers.Random(), alphabet, frequencyMatrix));
			}
		}
	}
}

namespace Sandbox
{
	static class ProblemC
	{
		public static void ConsoleInput()
		{
			var k = Console.ReadLine();
			var encodedArray = Console.ReadLine();

			Console.WriteLine(MySolution(k, encodedArray));
		}

		public static void Test()
		{
			var testFiles = Directory.GetFiles(@"..\..\..\TestData\ProblemC");

			foreach (var testInput in testFiles.Where(tf => !tf.EndsWith(".a")))
			{
				Console.WriteLine($"Test {testInput.Substring(testInput.Length - 2, 2)}:");
				var inputs = File.ReadAllLines(testInput);

				var result = MySolution(inputs[0], inputs[1]);

				var testResult = testFiles.FirstOrDefault(tf => tf == testInput + ".a");

				if (result == File.ReadAllText(testResult).Trim())
					Console.WriteLine("Passed.");
				else
					Console.WriteLine("Not passed.");
			}
		}

		public static string MySolution(string kAsString, string encodedArrayAsString)
		{
			var k = int.Parse(kAsString);
			var encodedArray = encodedArrayAsString.Split(" ").Select(int.Parse).ToArray();

			var decodedArray = new int[k + 1];

			var indexOfZero = 0;

			var first = 0;
			for (var i = 0; i < encodedArray.Length; i++)
			{
				var delta = encodedArray[i];
				var second = first + delta;

				if (second < 0)
				{
					indexOfZero = i + 1;
					first = 0;
					continue;
				}

				first = second;
				decodedArray[i + 1] = first;
			}

			var last = 0;
			for (var j = indexOfZero - 1; j >= 0; j--)
			{
				var delta = encodedArray[j];
				var previous = last - delta;

				last = previous;
				decodedArray[j] = last;
			}

			return string.Join(" ", decodedArray);
		}
	}
}
namespace Sandbox
{
	static class ProblemD
	{
		public static void ConsoleInput()
		{
			var s = Console.ReadLine();
			var t = Console.ReadLine();

			Console.WriteLine(MySolution(s, t));
		}

		public static void Test()
		{
			var testFiles = Directory.GetFiles(@"..\..\..\TestData\ProblemD");

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

		public static string MySolution(string s, string t)
		{
			var word = s.ToArray();
			var guess = t.ToArray();

			var colors = new char[word.Length];

			var availableLetters = new Dictionary<char, int>();
			foreach (var group in word.GroupBy(key => key))
			{
				availableLetters.Add(group.Key, group.ToList().Count);
			}

			for (var i = 0; i < guess.Length; i++)
			{
				var candidate = guess[i];

				if (candidate == word[i])
				{
					colors[i] = 'G';
					availableLetters[candidate]--;
				}
				else
				{
					colors[i] = '?';
				}
			}

			for (var j = 0; j < word.Length; j++)
			{
				if (colors[j] == '?')
				{
					var candidate = guess[j];

					if (availableLetters.ContainsKey(candidate) && availableLetters[candidate] > 0)
					{
						colors[j] = 'Y';
						availableLetters[candidate]--;
					}
					else
					{
						colors[j] = '.';
					}
				}
			}

			return string.Join(string.Empty, colors);
		}
	}
}
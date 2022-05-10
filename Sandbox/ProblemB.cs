namespace Sandbox
{
	static class ProblemB
	{
		public static void MySolution()
		{
			var t = short.Parse(Console.ReadLine());

			for (var index = 0; index < t; index++)
			{
				var n = int.Parse(Console.ReadLine());
				var set = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

				if (n == 1)
				{
					Console.WriteLine(1);
					continue;
				}

				var valuesToPrioritize = new LinkedList<int>(set.Distinct().OrderByDescending(x => x));

				var priorityValuesDictionary = new Dictionary<int, int>();

				var currentPriority = 1;

				do
				{
					var max = valuesToPrioritize.First;
					priorityValuesDictionary.Add(max.Value, currentPriority);

					if (max.Next is LinkedListNode<int> nextNode && nextNode.Value == max.Value - 1)
					{
						priorityValuesDictionary.Add(nextNode.Value, currentPriority);
						valuesToPrioritize.Remove(nextNode);
					}

					valuesToPrioritize.Remove(max);

					currentPriority++;
				} while (valuesToPrioritize.Count > 0);

				Console.WriteLine(string.Join(" ", set.Select(x => priorityValuesDictionary[x])));
			}
		}
	}
}
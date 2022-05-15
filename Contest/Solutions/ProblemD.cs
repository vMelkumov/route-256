namespace Contest.Solutions
{
	internal class ProblemD
	{
		static void Execute()
		{
			var quantityOfInputs = int.Parse(Console.ReadLine());

			for (var inputIndex = 0; inputIndex < quantityOfInputs; inputIndex++)
			{
				var quantityOfEntries = int.Parse(Console.ReadLine());

				var journalEntries = new Stack<(string, string)>();
				for (var entryIndex = 0; entryIndex < quantityOfEntries; entryIndex++)
				{
					var entryData = Console.ReadLine().Split(' ');
					journalEntries.Push((entryData[0], entryData[1]));
				}

				ProcessJournalEntries(journalEntries);

				Console.WriteLine();
			}

			static void ProcessJournalEntries(Stack<(string name, string number)> entries)
			{
				var addressBookDictionary = new Dictionary<string, HashSet<string>>();

				while (entries.Count > 0)
				{
					var entry = entries.Pop();

					if (addressBookDictionary.ContainsKey(entry.name))
					{
						var addresses = addressBookDictionary[entry.name];

						if (addresses.Count < 5 && !addresses.Contains(entry.number))
							addresses.Add(entry.number);
					}
					else
					{
						addressBookDictionary.Add(entry.name, new HashSet<string> { entry.number });
					}
				}

				foreach (var address in addressBookDictionary.OrderBy(a => a.Key, StringComparer.OrdinalIgnoreCase))
				{
					Console.WriteLine("{0}: {1} {2}", address.Key, address.Value.Count, string.Join(" ", address.Value));
				}
			}
		}
	}
}

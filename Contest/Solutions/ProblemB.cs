namespace Contest.Solutions
{
	internal class ProblemB
	{
		public static void Execute()
		{
			var quantityOfInputs = int.Parse(Console.ReadLine());

			for (var inputIndex = 0; inputIndex < quantityOfInputs; inputIndex++)
			{
				// Divider between data sets - an empty string.
				Console.ReadLine();

				var tableSizes = StringToIntArray(Console.ReadLine());
				(int rowCount, int columnCount) = (tableSizes[0], tableSizes[1]);

				var table = new int[rowCount][];

				for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
				{
					var rowValues = StringToIntArray(Console.ReadLine());
					table[rowIndex] = rowValues;
				}

				var quantityOfClicks = int.Parse(Console.ReadLine());
				var clickOrder = StringToIntArray(Console.ReadLine());

				var previousClick = -1;
				for (var clickIndex = 0; clickIndex < quantityOfClicks; clickIndex++)
				{
					if (clickOrder[clickIndex] != previousClick)
					{
						Sort(table, clickOrder[clickIndex] - 1);
					}

					previousClick = clickOrder[clickIndex];
				}

				foreach (var row in table)
				{
					Console.WriteLine(string.Join(" ", row));
				}

				Console.WriteLine();
			}


			int[] StringToIntArray(string str) => str.Split(' ').Select(int.Parse).ToArray();

			// TODO: Must use a stable sort algorithm.

			void Sort(int[][] table, int columnIndex)
			{
				var columnArray = new int[table.Length];

				Comparer<int> comparer = Comparer<int>.Default;
				Array.Sort(table, (x, y) => comparer.Compare(x[columnIndex], y[columnIndex]));
			}
		}
	}
}
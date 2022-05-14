namespace Sandbox
{
	static class ProblemE1
	{
		public static void MySolution()
		{
			var quantityOfInputData = short.Parse(Console.ReadLine());

			for (short inputIndex = 0; inputIndex < quantityOfInputData; inputIndex++)
			{
				// Divider between inputs - an empty string.
				Console.ReadLine();

				var quantityOfTasks = int.Parse(Console.ReadLine());

				var taskQueue = new Queue<(int, short)>(quantityOfTasks);

				for (var taskIndex = 0; taskIndex < quantityOfTasks; taskIndex++)
				{
					var taskData = Console.ReadLine().Split(' ');
					(int, short) task = (int.Parse(taskData[0]), short.Parse(taskData[1]));

					taskQueue.Enqueue(task);
				}

				ProcessTaskQueue(taskQueue);
			}
		}

		public static void Test()
		{
			var testFiles = Directory.GetFiles(@"..\..\..\TestData\ProblemE1");

			foreach (var testInput in testFiles.Where(tf => !tf.EndsWith(".a")))
			{
				Console.WriteLine($"Test {testInput.Substring(testInput.Length - 2, 2)}:");

				string[] results;

				using (var reader = new StreamReader(testInput))
				{
					var quantityOfInputData = short.Parse(reader.ReadLine());

					results = new string[quantityOfInputData];

					for (short inputIndex = 0; inputIndex < quantityOfInputData; inputIndex++)
					{
						// Divider between inputs - an empty string.
						reader.ReadLine();

						var quantityOfTasks = int.Parse(reader.ReadLine());

						var taskQueue = new Queue<(int, short)>(quantityOfTasks);

						for (var taskIndex = 0; taskIndex < quantityOfTasks; taskIndex++)
						{
							var taskData = reader.ReadLine().Split(' ');
							(int, short) task = (int.Parse(taskData[0]), short.Parse(taskData[1]));

							taskQueue.Enqueue(task);
						}

						results[inputIndex] = ProcessTaskQueue(taskQueue);
					}
				}

				var testResultsPath = testFiles.FirstOrDefault(tf => tf == testInput + ".a");

				var testResults = File.ReadAllLines(testResultsPath);

				for (int i = 0; i < testResults.Length; i++)
				{
					if (testResults[i].Trim() != results[i])
						Console.WriteLine("Not passed.");
				}

				Console.WriteLine("Passed.");
			}
		}

		//
		static string ProcessTaskQueue(Queue<(int time, short duration)> queueOfTasks)
		{
			var finishedTasksTimes = new int[queueOfTasks.Count];

			var serverAvailableTime = 0;

			while (queueOfTasks.Count > 0)
			{
				var task = queueOfTasks.Dequeue();

				if (task.time > serverAvailableTime)
				{
					serverAvailableTime = task.time;
				}

				var taskFinishedTime = serverAvailableTime + task.duration;

				var taskFinishedTimeIndex = finishedTasksTimes.Length - queueOfTasks.Count - 1;
				finishedTasksTimes[taskFinishedTimeIndex] = taskFinishedTime;

				serverAvailableTime = taskFinishedTime;
			}

			var result = string.Join(" ", finishedTasksTimes);

			//Console.WriteLine(result);

			return result;
		}
	}
}
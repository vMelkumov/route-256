using System.Text.RegularExpressions;

namespace Contest.Solutions
{
	internal class ProblemC
	{
		const string YES_WORD = "YES";
		const string NO_WORD = "NO";

		static readonly Regex regex = new(@"^[A-Za-z0-9-_]+$");

		static void Execute()
		{
			var quantityOfInputs = int.Parse(Console.ReadLine());

			for (var inputIndex = 0; inputIndex < quantityOfInputs; inputIndex++)
			{
				var quantityOfAttempts = int.Parse(Console.ReadLine());

				var attempts = new Queue<string>();
				for (var attemptIndex = 0; attemptIndex < quantityOfAttempts; attemptIndex++)
				{
					attempts.Enqueue(Console.ReadLine());
				}

				var checkedLogins = new HashSet<string>();

				while (attempts.Count > 0)
				{
					var loginToCheck = attempts.Dequeue().ToUpperInvariant();

					if (!checkedLogins.Contains(loginToCheck) && IsLoginValid(loginToCheck))
					{
						checkedLogins.Add(loginToCheck);

						Console.WriteLine(YES_WORD);
					}
					else
					{
						Console.WriteLine(NO_WORD);
					}
				}

				Console.WriteLine();
			}

			static bool IsLoginValid(string login)
			{
				if (regex.Match(login).Success)
				{
					var length = login.Length;
					if (length >= 2 && length <= 24 && login[0] != '-')
					{
						return true;
					}

				}

				return false;
			}
		}
	}
}
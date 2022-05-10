var t = short.Parse(Console.ReadLine());

for (var index = 0; index < t; index++)
{
    var n = int.Parse(Console.ReadLine());
    var valuesToPrioritize = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();

    if (n == 1)
    {
        Console.WriteLine(1);
        continue;
    }

    var priorityValuesDictionary = new Dictionary<int,int>();
    var copy = new List<int>(valuesToPrioritize);
    var initial = true;
    var currentPriority = 1;

    do 
    {
        var max = copy.Max();

        if (initial)
        {
            var maxPriorityValues = copy.Distinct().Where(x => x == max || x == max - 1).ToList();
            
            maxPriorityValues.ForEach(v => priorityValuesDictionary.Add(v, currentPriority));

            copy.RemoveAll(x => x == max || x == max - 1);

            initial = false;
        }
        else
        {
            priorityValuesDictionary.Add(max, currentPriority);
            copy.RemoveAll(x => x == max);
        }

        currentPriority++;
    } while (copy.Count() != 0);

    Console.WriteLine(string.Join(" ", valuesToPrioritize.Select(x => priorityValuesDictionary[x])));
}

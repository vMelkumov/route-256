using System.Diagnostics;

namespace Sandbox
{
    static class ProblemC
    {
        public static void MySolution(string[] args)
        {
            //var k = int.Parse(Console.ReadLine());
            var k = int.Parse(args[0]);
            //var encodedArray = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            var encodedArray = args[1].Split(" ").Select(int.Parse).ToArray();

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

            Console.WriteLine(string.Join(" ", decodedArray));
        }
    }
}
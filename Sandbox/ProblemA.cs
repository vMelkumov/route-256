namespace Sandbox
{
    static class ProblemA
    {
        // Использовано: 77 мс, 2108 КБ
        public static void MySolution()
        {
            var t = Convert.ToUInt16(Console.ReadLine());

            string set;

            for (var index = 0; index < t; index++)
            {
                set = Console.ReadLine();

                Console.WriteLine(set.Split(" ").Select(x => Convert.ToInt32(x)).Aggregate((a, b) => a + b));
            }
        }
    }
}
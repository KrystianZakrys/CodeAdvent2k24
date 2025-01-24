
namespace CodeAdvent2k24.Day1
{
    public static class Day1TaskSolution
    {
        public static List<int> List1 = new List<int> {3,4,2,1,3,3 };
        public static List<int> List2 = new List<int> { 4, 3, 5,3, 9, 3 };

        public static  void Run()
        {
            Console.WriteLine("LinqImplementation_ZipEnumarable_OneLiner");
            LinqImplementation_ZipEnumarable_OneLiner();
            Console.WriteLine();

            LinqImplementation_ZipIEnumerable();
            SimpleImplementation_ForLoop();
        }

        public static void LinqImplementation_ZipEnumarable_OneLiner()
        {
            Console.WriteLine(List1.OrderBy(x => x).Zip(List2.OrderBy(x=>x), (x, y) => Math.Abs(x-y)).Sum());
        }


        public static void LinqImplementation_ZipIEnumerable()
        {
            var sortedList1 = List1.OrderBy(x => x);
            var sortedList2 = List2.OrderBy(x => x);
            var totalDistance = sortedList1.Zip(sortedList2, (x, y) => Math.Abs(x - y)).Sum();

            Console.WriteLine("LinqImplementation_ZipIEnumerable");
            Console.WriteLine(totalDistance);
            Console.WriteLine();

        }

        public static void SimpleImplementation_ForLoop()
        {
            var sortedList1 = List1.OrderBy(x => x).ToList();
            var sortedList2 = List2.OrderBy(x => x).ToList();
            int totalDistance = 0;

            for (int i = 0; i < sortedList1.Count; i++)
            {
                totalDistance += Math.Abs(sortedList1[i] - sortedList2[i]);
            }

            Console.WriteLine("SimpleImplementation_ForLoop");
            Console.WriteLine(totalDistance);
            Console.WriteLine();
        }
    }
}

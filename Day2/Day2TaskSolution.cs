
namespace CodeAdvent2k24.Day1
{
    public static class Day2TaskSolution
    {
        public static List<List<int>> reports = new List<List<int>>() 
        { 
            new List<int>(){7,6,4,2,1},
            new List<int>(){1,2,7,8,9},
            new List<int>(){9, 7, 6, 2, 1},
            new List<int>(){1, 3, 2, 4, 5},
            new List<int>(){8, 6, 4, 4, 1},
            new List<int>(){1, 3, 6, 7, 9}
        };

        public static  void Run()
        {
            SimpleImplementation_2ForLoops();
        }

        public static void SimpleImplementation_2ForLoops()
        {
            for (int i = 0; i < reports.Count; i++) {
                bool? isIncreasing = null;
                string result = $"Report {i} is SAFE";

                for (int j = 0; j < reports[i].Count - 1; j++)
                {
                    if (!isIncreasing.HasValue)
                    {
                        isIncreasing = reports[i][j] < reports[i][j + 1] ? true : false;
                    }

                    if ((reports[i][j] > reports[i][j + 1]) && isIncreasing.Value)
                    {
                        result = $"[X] Report {i} is UNSAFE";
                        break;
                    }

                    if ((reports[i][j] < reports[i][j + 1]) && !isIncreasing.Value)
                    {
                        result = $"[X] Report {i} is UNSAFE";
                        break;
                    }

                    if(Math.Abs(reports[i][j] - reports[i][j + 1]) < 1 || Math.Abs(reports[i][j] - reports[i][j + 1]) > 3){
                        result = $"[X] Report {i} is UNSAFE";
                        break;
                    }
                }

                Console.WriteLine(result);
            }
        }

        delegate bool ReportValidityPolicy(List<int> report);
        static ReportValidityPolicy OnlyIncreasing => input => false;
        static ReportValidityPolicy OnlyDecreasing => input => false;
        static ReportValidityPolicy DiffBetween(int min, int max) => input => false;

        public static void SpecificationImplementation_Delegate()
        {

        }
    }
}



using System.Text.RegularExpressions;

namespace CodeAdvent2k24.Day1
{
    public static class Day3TaskSolution
    {
        static string corruptedMemory = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))\r\n";
        static string regexPattern = @"mul\(\d{1,3},\d{1,3}\)";        

        public static  void Run()
        {
            var matches = Regex.Matches(corruptedMemory, regexPattern);
            var result = 0;
            foreach (Match match in matches)
            {
                var numbers = Regex.Matches(match.Value, "\\d{1,3}");
                var multiplyResult = 1;
                foreach (var num in numbers)
                {
                    if(Int32.TryParse(num.ToString(), out int number))
                    {
                        multiplyResult *= number;
                    }
                }
                result += multiplyResult;
            }

            Console.WriteLine(result);
        }
        
    }
    
}

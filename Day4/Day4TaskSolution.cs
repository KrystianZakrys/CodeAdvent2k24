

using System.Text.RegularExpressions;

namespace CodeAdvent2k24.Day1
{
    public static class Day4TaskSolution
    {
        public static string[] input = [
            "MMMSXXMASM",
            "MSAMXMSMSA",
            "AMXSXMAAMM",
            "MSAMASMSMX",
            "XMASAMXAMM",
            "XXAMMXXAMA",
            "SMSMSASXSS",
            "SAXAMASAAA",
            "MAMMMXMMMM",
            "MXMXAXMASX"
            ];
        
        public static void Run()
        {
            PrintMatchesCount();
        }

        public static void PrintMatchesCount()
        {
            var inputHeight = input.Count();
            var inputWidth = input[0].Count();
            var counter = 0;


            for (var x = 0; x < inputHeight; x++)
            {
                for (var y = 0; y < inputWidth; y++)
                {
                    if (input[x][y] == 'X')
                    {
                        SearchForStringEveryDirection("XMAS", input, (x,y));
                    }
                    else if (input[x][y] == 'S')
                    {
                        SearchForStringEveryDirection("SMAX", input, (x, y));
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            Console.WriteLine($"Found {counter} matches");
        }
        public static void SearchForStringEveryDirection(string criteria, string[] input, (int x, int y) currentCharacter)
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>()
            keyValuePairs.Add("left", "");
            keyValuePairs.Add("leftTop", "");
            keyValuePairs.Add("top", "");
            keyValuePairs.Add("rightTop", "");
            keyValuePairs.Add("right", "");
            keyValuePairs.Add("rightBottom", "");
            keyValuePairs.Add("bottom", "");
            keyValuePairs.Add("leftBottom", "");


            for (var i = 1; i < criteria.Length; i++) { 
                if(currentCharacter.x - i < 0)
                {
                    //sprawdzaj tylko w dół
                    if (currentCharacter.y - i < 0)
                    {                        
                    }

                    if (currentCharacter.y + 1 > input[0].Length)
                    {
                        //SPRAWDZAJ TYLKO W lewo
                    }
                }

                if (currentCharacter.x + 1 > input.Length)
                {
                    //SPRAWDZAJ TYLKO W GÓRĘ

                    //sprawdzaj tylko w dół
                    if (currentCharacter.y - i < 0)
                    {
                        //sprawdzaj tylko w prawo
                    }

                    if (currentCharacter.y + 1 > input[0].Length)
                    {
                        //SPRAWDZAJ TYLKO W lewo
                    }
                }
            }
        }
    }
    
}



using System.Text;
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


        public static List<List<(int x, int y)>> FoundIndexes = new List<List<(int x, int y)>>();
        public static bool IsAlreadyCrossed(List<(int x, int y)> indexesToCheck)
        {
            var directionMatchedIndexes = indexesToCheck
                .OrderBy(x => x.x)
                .ThenBy(y => y.y);

            var alreadyCrossed = FoundIndexes.Any(l => l.OrderBy(x => x.x)
                .ThenBy(y => y.y)
                .SequenceEqual(directionMatchedIndexes))
                ;

            return alreadyCrossed;
        }

        public static void Run()
        {
            PrintMatchesCount();
        }

        public static string Reverse(this string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray); ;
        }
        public static void PrintMatchesCount()
        {
            var searchString = "XMAS";
            var inputHeight = input.Count();
            var inputWidth = input[0].Count();
            var counter = 0;

            for (var x = 0; x < inputHeight; x++)
            {
                for (var y = 0; y < inputWidth; y++)
                {

                    if (input[x][y] == 'X')
                    {
                        counter += CountMatches(searchString, ref input, (x,y));
                    }
                    else if (input[x][y] == 'S')
                    {
                        counter += CountMatches(searchString.Reverse(), ref input, (x, y));
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            
            Console.WriteLine($"Found {counter} matches");            
        }

        public static void PrintInput(string[] input)
        {
            foreach (var x in input) Console.WriteLine(x);
        }

        public struct DirectionMatching
        {
            public Func<int, (int x, int y)> CalculateDirectionIndex;
            public List<(int x, int y)> MatchedIndexes = new List<(int x, int y)>();

            public DirectionMatching(Func<int, (int x, int y)> calculateDirectionIndex)
            {
                CalculateDirectionIndex = calculateDirectionIndex;
            }
         
        }
        public static int CountMatches(string criteria, ref string[] input, (int x, int y) currentCharacter)
        {
            int count = 0;

            Dictionary<string, DirectionMatching> directions = new Dictionary<string, DirectionMatching>();
            var left = (int i) =>
            {
                return (x: currentCharacter.x, y: currentCharacter.y - i);
            };
            
            var topLeft = (int i) =>
            {
                return (x: currentCharacter.x - i, y: currentCharacter.y - i);
            };

            var top = (int i) =>
            {
                return (x: currentCharacter.x - i, y: currentCharacter.y);
            };

            var topRight = (int i) =>
            {
                return (x: currentCharacter.x - i, y: currentCharacter.y + i);
            };

            var right = (int i) =>
            {
                return (x: currentCharacter.x, y: currentCharacter.y + i);
            };

            var bottomRight = (int i) =>
            {
                return (x: currentCharacter.x + i, y: currentCharacter.y + i);
            };

            var bottom = (int i) =>
            {
                return (x: currentCharacter.x + i, y: currentCharacter.y);
            };

            var bottomLeft = (int i) =>
            {
                return (x: currentCharacter.x + i, y: currentCharacter.y - i);
            };

            directions.Add("left", new DirectionMatching(left));
            directions.Add("topLeft", new DirectionMatching(topLeft));
            directions.Add("top", new DirectionMatching(top));
            directions.Add("topRight", new DirectionMatching(topRight));
            directions.Add("right", new DirectionMatching(right));
            directions.Add("bottomRight", new DirectionMatching(bottomRight));
            directions.Add("bottom", new DirectionMatching(bottom));
            directions.Add("bottomLeft", new DirectionMatching(right));

            var inputCopy = input;

            var IsInside = ((int x, int y) coordinates) =>
                coordinates.x >= 0 && coordinates.x < inputCopy.Length && coordinates.y >= 0 && coordinates.y < inputCopy[0].Length;

            var IsAlreadyCrossed = (string direction) =>
            {
                var directionMatchedIndexes = directions[direction].MatchedIndexes
                    .OrderBy(x => x.x)
                    .ThenBy(y => y.y);

                var alreadyCrossed = directions.Any(d => d.Key != direction && d.Value.MatchedIndexes
                    .OrderBy(x => x.x)
                    .ThenBy(y => y.y)
                    .SequenceEqual(directionMatchedIndexes));

                return alreadyCrossed;               
            };
                

            for (var i = 1; i < criteria.Length; i++) {
                foreach (var direction in directions)
                {
                    if(i == 1)
                    {
                        direction.Value.MatchedIndexes.Add(currentCharacter);
                    }

                    var directionCoordinates = direction.Value.CalculateDirectionIndex(i);
                    if (IsInside(directionCoordinates) 
                        && input[directionCoordinates.x][directionCoordinates.y] == criteria[i])
                    {
                        direction.Value.MatchedIndexes.Add(directionCoordinates);
                        if (i == criteria.Length - 1 && !IsAlreadyCrossed(direction.Key)) {
                            if (!Day4TaskSolution.IsAlreadyCrossed(direction.Value.MatchedIndexes))
                            {
                                count++;
                                FoundIndexes.Add(direction.Value.MatchedIndexes);
                            }

                        }
                    }
                    else
                    {
                        directions.Remove(direction.Key);
                    }
                }            
            }

            return count;
        }
    }
    
}

namespace String_Pattern_Detector
{
    internal class Program
    {
        static void Main()
        {
            string pattern = "";
            int repeatCount = 0;
            bool patternDetected = false;

            string text = EnterString();

            List<int> multiple = DivideStringInParts(text.Length);

            patternDetected = DetectPattern(text, multiple, out pattern, out repeatCount);

            Console.WriteLine(ShowResult(patternDetected, pattern, repeatCount));





            string EnterString()
            {
                string text = "";

                while (text == "")
                {
                    Console.WriteLine("Enter the character string from which you want to find a pattern:");
                    text = Console.ReadLine();
                }

                return text;
            }

            List<int> DivideStringInParts(int textLength)
            {
                List<int> multiple = new List<int>();

                for (int i = 2; i <= textLength; i++)
                {
                    if (textLength % i == 0)
                    {
                        multiple.Add(i);
                    }
                }

                return multiple;
            }

            bool DetectPattern(string text, List<int> multiple, out string pattern, out int repeatCount)
            {
                pattern = "";
                repeatCount = 0;

                for (int i = multiple.Count - 1; i >= 0; i--)
                {
                    pattern = text.Substring(0, text.Length / multiple[i]);
                    string str = "";

                    for (int j = 1; j <= multiple[i]; j++)
                    {
                        str += pattern;
                    }

                    if (str == text)
                    {
                        repeatCount = multiple[i];
                        return true;
                    }
                }

                return false;
            }

            string ShowResult(bool patternDetected, string pattern, int repeatCount)
            {
                if (patternDetected)
                {
                    return $"\nThe following pattern has been detected:\n{pattern}\n\nThe pattern repeats itself {repeatCount} times in the given string.";
                }

                else
                {
                    return "\nNo pattern has been detected.";
                }
            }
        }
    }
}

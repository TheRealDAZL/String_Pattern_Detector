namespace String_Pattern_Detector
{
    internal class Program
    {
        static void Main()
        {
            string pattern = "";
            int repeatCount = 0;

            string text = EnterString();

            DetectPattern(text, out pattern, out repeatCount);

            Console.WriteLine(ShowResult(pattern, repeatCount));





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

            void DetectPattern(string text, out string pattern, out int repeatCount)
            {
                int textLength = text.Length;

                for (repeatCount = textLength; repeatCount > 1 ; repeatCount--)
                {
                    if (textLength % repeatCount == 0)
                    {
                        pattern = text.Substring(0, textLength / repeatCount);
                        string str = "";

                        for (int steps = 1; steps <= repeatCount; steps++)
                        {
                            str += pattern;
                        }

                        if (str == text)
                        {
                            return;
                        }
                    }
                }

                pattern = "";
                repeatCount = 0;
            }

            string ShowResult(string pattern, int repeatCount)
            {
                if (repeatCount != 0)
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

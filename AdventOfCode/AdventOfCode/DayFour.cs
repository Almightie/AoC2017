namespace AdventOfCode
{
    public class DayFour
    {
        public bool IsPassPhraseValid(string input)
        {
            string[] inputParts = input.Split(' ');
            for (int i = 0; i < inputParts.Length; i++)
            {
                for (int j = 0; j < inputParts.Length; j++)
                {
                    if (i != j)
                    {
                        if (inputParts[i] == inputParts[j])
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public int GetNumberOfValidPassPhrases(string[] input)
        {
            int sum = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (IsPassPhraseValid(input[i]))
                {
                    sum++;
                } 
            }

            return sum;
        }

        public bool IsPassPhraseV2Valid(string input)
        {
            string[] inputParts = input.Split(' ');
            for (int i = 0; i < inputParts.Length; i++)
            {
                for (int j = 0; j < inputParts.Length; j++)
                {
                    if (i != j)
                    {
                        if (inputParts[i].Length >= inputParts[j].Length)
                        {
                            if (IsAnagram(inputParts[i], inputParts[j]))
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        private bool IsAnagram(string word1, string word2)
        {

            for (int x = 0; x < word1.Length; x++)
            {
                bool letterFound = false;

                for (int y = 0; y < word2.Length; y++)
                {
                    if (word1.Contains(word2[y].ToString()) && word2.Contains(word1[x].ToString()))
                    {
                        letterFound = true;
                    }
                    if (!letterFound)
                    {
                        return false;
                    }
                }
               
            }
            return true;
        }
    }
}

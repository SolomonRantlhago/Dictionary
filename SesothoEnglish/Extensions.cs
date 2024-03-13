using libDictionary;

namespace SesothoEnglish
{
    public static class Extensions
    {
        public static void SelectionSort(this Dictionary dictionary, Languages language)
        {
            SelectionSort(dictionary, language, dictionary.Count-1);
        } //SelectionSort

        //Helper methods
        private static void SelectionSort(Dictionary dictionary, Languages language, int to)
        {
            if (to > 0)
            {
                int indexOfMax = IndexOfMax(dictionary, language, to);

                //Swap1
                string[] tmp = dictionary[indexOfMax];
                dictionary[indexOfMax] = dictionary[to];
                dictionary[to] = tmp;

                //Sort smaller array
                SelectionSort(dictionary, language, to - 1);
            }
        } //SelectionSort

        private static int IndexOfMax(Dictionary dictionary, Languages language, int to)
        {
            string[] max = new string[] { "", "" };
            int idx = -1;
            for (int i = 0; i <= to; i++)
            {
                if (dictionary[i][(int)language].After(max[(int)language]))
                {
                    max = dictionary[i];
                    idx = i;
                }
            }
            return idx;
        } //MaxIndex

        private static bool After (this string word1, string word2)
        {
            int i = word1.CompareTo(word2);
            return i == 1;
        } //After

        public static int BinarySearch(this Dictionary dictionary, string word)
        {
            SelectionSort(dictionary, Languages.English);
            int i = BinarySearch(dictionary, Languages.English, 0, dictionary.Count - 1, word);
            if (i == -1) //Not found in English, try the Sesotho
            {
                SelectionSort(dictionary, Languages.Sesotho);
                i = BinarySearch(dictionary, Languages.Sesotho, 0, dictionary.Count - 1, word);
            }
            return i;
        } //public BinarySearch

        private static int BinarySearch(Dictionary dictionary, Languages language, int lower, int upper, string word)
        {
            if (lower <= upper)
            {
                int mid = (lower + upper) / 2;
                string compareWith = dictionary[mid][(int)language];
                int i = word.CompareTo(compareWith);
                if (i == -1)
                    return BinarySearch(dictionary, language, lower, mid - 1, word);
                else
                    if (i == 1)
                    return BinarySearch(dictionary, language, mid + 1, upper, word);
                else
                    return mid;
            } //if (lower <= upper)

            return -1;
        } //BinarySearch

    } //Extensions
}

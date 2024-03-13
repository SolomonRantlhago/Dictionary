using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace libDictionary
{
    public enum Languages
    {
        Sesotho = 0, English = 1
    } //enum Languages

    interface IDictionary
    {
        int Count { get; }
        IEnumerator<string[]> GetEnumerator();
        bool Contains(string word);
        string[] this[int i] { get; set; }
        string[] this[string word] { get; }
        void Sort(Languages language);
    } //interface IDictionary

    public class Dictionary : IDictionary
    {
        private List<string[]> lstWords;

        public Dictionary()
        {
            lstWords = new List<string[]>();
            ReadWords();
        } //Constructor

        private void ReadWords()
        {
            if (File.Exists("Sesotho-English.txt"))
                using (StreamReader f = new StreamReader("Sesotho-English.txt"))
                {
                    while (!f.EndOfStream)
                    {
                        string[] sLine = f.ReadLine().Split('\t');
                        lstWords.Add(new string[] { sLine[0], sLine[1] });
                    }
                } //using

        } //ReadWords

        public int Count
        {
            get { return lstWords.Count; }
        } //Count

        public IEnumerator<string[]> GetEnumerator()
        {
            foreach (string[] element in lstWords)
                yield return element; 
        } //GetEnumerator

        //Contains
        public bool Contains(string word)
        {
            return lstWords.FirstOrDefault(s => s[0].ToUpper().Replace(" ", "") == word.ToUpper().Replace(" ", "")
                                             || s[1].ToUpper().Replace(" ", "") == word.ToUpper().Replace(" ", "")
                                          ) != null;
        } //Contains

        //Indexers
        public string[] this[int i]
        {
            get { return lstWords[i]; }
            set { lstWords[i] = value; }
        } //Indexer 2

        public string[] this[string word]
        {
            get { return lstWords.FirstOrDefault(s => s[0].ToUpper().Replace(" ", "") == word.ToUpper().Replace(" ", "") 
                                                   || s[1].ToUpper().Replace(" ", "") == word.ToUpper().Replace(" ", "")); }
        } //Indexer 2

        public void Sort(Languages language)
        {
            if (language == Languages.English)
                lstWords.Sort(CompareToEnglish);
            else
                lstWords.Sort(CompareToSesotho);
        } //Sort

        private int CompareToSesotho(string[] x, string[] y)
        {
            return x[0].CompareTo(y[0]);
        } //CompareToSesotho

        private int CompareToEnglish(string[] x, string[] y)
        {
            return x[1].CompareTo(y[1]);
        } //CompareToEnglish

    } //class Dictionary
}

using System;
using libDictionary;

namespace SesothoEnglish
{
    class Program
    {        
        static void Main()
        {
            //Black text on white background
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            //Instantiate dictionary
            Dictionary dictionary = new Dictionary();

            //Call menu
            Menu(dictionary); 
        } //Main

        private static void Menu(Dictionary dictionary)
        {
            Console.Clear();
            Console.WriteLine();

            //Display options
            Console.WriteLine("\t1. List all (English alphabetical order)");
            Console.WriteLine("\t2. List all (Sesotho alphabetical order)");
            Console.WriteLine("\t3. Translate");
            Console.WriteLine("\tX. Exit");
            Console.WriteLine();
            Console.Write("\tEnter option: ");

            //Read user choice
            char option = Console.ReadKey().KeyChar.ToString().ToUpper()[0];

            //Do user choice
            switch (option)
            {
                case '1': List(dictionary, Languages.English); Menu(dictionary); break;
                case '2': List(dictionary, Languages.Sesotho); Menu(dictionary); break;
                case '3': Translate(dictionary); Menu(dictionary); break;
                case 'X': break;
                default: Menu(dictionary); break;
            }
        } //Menu

        private static void List(Dictionary dictionary, Languages language)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\tList of words in " + language + " alphabetical order\n");

            //Sort the words in the dictionary
            //dictionary.Sort(language);
            dictionary.SelectionSort(language);
            
            //List all words
            foreach (string[] words in dictionary)
                Console.WriteLine("\t" + words[0].PadRight(20) + words[1]);

            Console.WriteLine();
            Console.Write("\tPress any key to return to the menu ..."); Console.ReadKey();
        } //List

        private static void Translate(Dictionary dictionary)
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\tTranslation of a word\n");

            //Get word from user
            Console.Write("\tEnglish or Sesotho : ");
            string word = Console.ReadLine();

            //Display word and its translation
            if (dictionary.Contains(word))
            {
                Console.WriteLine("\tSesotho: " + dictionary[word][0]);
                Console.WriteLine("\tEnglish: " + dictionary[word][1]);
            }
            else
                Console.WriteLine("\tThe dictionary does not contain the word '" + word + "'.");

            //int i = dictionary.BinarySearch(word);
            //if (i != -1)
            //{
            //    Console.WriteLine("\tSesotho: " + dictionary[i][0]);
            //    Console.WriteLine("\tEnglish: " + dictionary[i][1]);
            //}
            //else
            //    Console.WriteLine("\tThe dictionary does not contain the word '" + word + "'.");

            Console.WriteLine();
            Console.Write("\tPress any key to return to the menu ..."); Console.ReadKey();
        } //Translate

    } //class
} //namespace

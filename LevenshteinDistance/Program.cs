using System;
using System.Collections.Generic;

namespace LevenshteinDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Give me a word: ");
            string word1 = Console.ReadLine();

            Console.Write("Give me another word: ");
            string word2 = Console.ReadLine();

            Stack<LevenshteinOperation> operations = Levenshtein.CalculateEditOperations(word1, word2, out int ldist);
            foreach (LevenshteinOperation operation in operations)
            {
                Console.WriteLine("{0}: '{1}' -> '{2}'", operation.Operation, word1[operation.SourceIndex], word2[operation.DestinationIndex]);
            }
            Console.WriteLine("Levenshtein distance: {0}", ldist);

            // Exit
            Console.WriteLine("Press enter to exit...");
            Console.ReadLine();
        }

    }

}

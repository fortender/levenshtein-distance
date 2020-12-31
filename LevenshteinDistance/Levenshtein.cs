using System;
using System.Collections.Generic;

namespace LevenshteinDistance
{
    public static class Levenshtein
    {

        private static int CalculateDistance(string arg1, string arg2, out int[,] matrix)
        {
            int m = arg1.Length;
            int n = arg2.Length;
            int[,] D = new int[m + 1, n + 1];

            // Initialize vertical and horizontal empty string helper cells
            for (int i = 0; i < m + 1; i++)
                D[i, 0] = i;
            for (int j = 0; j < n + 1; j++)
                D[0, j] = j;

            for (int i = 1; i <= m; i++)
                for (int j = 1; j <= n; j++)
                {
                    int equal = D[i - 1, j - 1];
                    int replace = D[i - 1, j - 1] + 1;
                    int insert = D[i, j - 1] + 1;
                    int delete = D[i - 1, j] + 1;
                    D[i, j] = (arg1[i - 1] == arg2[j - 1]) ? MathHelper.Min(equal, replace, insert, delete) : MathHelper.Min(replace, insert, delete);
                }

            matrix = D;
            return D[m, n];
        }

        /// <summary>
        /// Calculates the Levenshtein distance between two strings. The Levenshtein distance is the minimal amount of edit operations needed to change <paramref name="arg1"/> into <paramref name="arg2"/>.
        /// </summary>
        /// <param name="arg1">Source string</param>
        /// <param name="arg2">Destination string</param>
        /// <returns>Levenshtein distance</returns>
        public static int CalculateDistance(string arg1, string arg2)
        {
            return CalculateDistance(arg1, arg2, out int[,] _);
        }

        /// <summary>
        /// Calculates one (minimal) sequence of edit operations that turns <paramref name="arg1"/> into <paramref name="arg2"/>.
        /// <para>Note: The sequence includes the <see cref="LevenshteinOperations.Nothing"/> operation.</para>
        /// </summary>
        /// <param name="arg1">Source string</param>
        /// <param name="arg2">Destination string</param>
        /// <param name="distance">Levenshtein distance</param>
        /// <returns></returns>
        public static Stack<LevenshteinOperation> CalculateEditOperations(string arg1, string arg2, out int distance)
        {
            distance = CalculateDistance(arg1, arg2, out int[,] D);

            int m = arg1.Length;
            int n = arg2.Length;

            var operationStack = new Stack<LevenshteinOperation>(Math.Max(m, n));
            BacktraceOperations(operationStack, D, m, n);

            return operationStack;
        }

        private static void BacktraceOperations(Stack<LevenshteinOperation> operations, int[,] matrix, int i, int j)
        {
            if (i <= 0 || j <= 0)
                return;

            if (matrix[i, j] == matrix[i - 1, j] + 1) // Delete
            {
                operations.Push(new LevenshteinOperation(i - 1, j - 1, LevenshteinOperations.Delete));
                BacktraceOperations(operations, matrix, i - 1, j);
            }
            else if (matrix[i, j] == matrix[i, j - 1] + 1) // Insert
            {
                operations.Push(new LevenshteinOperation(i - 1, j - 1, LevenshteinOperations.Insert));
                BacktraceOperations(operations, matrix, i, j - 1);
            }
            else if (matrix[i, j] == matrix[i - 1, j - 1] + 1) // Replace
            {
                operations.Push(new LevenshteinOperation(i - 1, j - 1, LevenshteinOperations.Replace));
                BacktraceOperations(operations, matrix, i - 1, j - 1);
            }
            else if (matrix[i, j] == matrix[i - 1, j - 1]) // Equal
            {
                operations.Push(new LevenshteinOperation(i - 1, j - 1, LevenshteinOperations.Nothing));
                BacktraceOperations(operations, matrix, i - 1, j - 1);
            }
        }

    }

}

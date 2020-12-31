namespace LevenshteinDistance
{

    public struct LevenshteinOperation
    {

        public LevenshteinOperation(int word1Index, int word2Index, LevenshteinOperations operation)
        {
            Word1Index = word1Index;
            Word2Index = word2Index;
            Operation = operation;
        }

        public int Word1Index { get; }

        public int Word2Index { get; }

        public LevenshteinOperations Operation { get; }

    }

}

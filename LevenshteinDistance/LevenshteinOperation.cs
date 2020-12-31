namespace LevenshteinDistance
{

    public struct LevenshteinOperation
    {

        public LevenshteinOperation(int sourceIndex, int destinationIndex, LevenshteinOperations operation)
        {
            SourceIndex = sourceIndex;
            DestinationIndex = destinationIndex;
            Operation = operation;
        }

        public int SourceIndex { get; }

        public int DestinationIndex { get; }

        public LevenshteinOperations Operation { get; }

    }

}

namespace AngbandOS.Core.WeightedRandoms
{
    internal class SingingPlayerAttacks : WeightedRandom<string>
    {
        public SingingPlayerAttacks()
        {
            Add(1, "sings 'We are a happy family.'");
            Add(1, "sings 'I love you, you love me.'");
        }
    }
}

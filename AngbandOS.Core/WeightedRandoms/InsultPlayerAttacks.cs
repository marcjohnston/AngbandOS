namespace AngbandOS.Core.WeightedRandoms
{
    internal class InsultPlayerAttacks : WeightedRandom<string>
    {
        public InsultPlayerAttacks()
        {
            Add(1, "insults you!");
            Add(1, "insults your mother!");
            Add(1, "gives you the finger!");
            Add(1, "humiliates you!");
            Add(1, "defiles you!");
            Add(1, "dances around you!");
            Add(1, "makes obscene gestures!");
            Add(1, "moons you!");
        }
    }
}

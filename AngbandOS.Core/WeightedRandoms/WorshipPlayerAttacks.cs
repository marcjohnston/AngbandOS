namespace AngbandOS.Core.WeightedRandoms
{
    internal class WorshipPlayerAttacks : WeightedRandom<string>
    {
        public WorshipPlayerAttacks()
        {
            Add(1, "looks up at you!");
            Add(1, "asks how many dragons you've killed!");
            Add(1, "asks for your autograph!");
            Add(1, "tries to shake your hand!");
            Add(1, "pretends to be you!");
            Add(1, "dances around you!");
            Add(1, "tugs at your clothing!");
            Add(1, "asks if you will adopt him!");
        }
    }
}

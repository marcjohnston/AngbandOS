namespace AngbandOS.Core.WeightedRandoms
{
    internal class MoanPlayerAttacks : WeightedRandom<string>
    {
        public MoanPlayerAttacks() 
        {
            Add(1, "seems sad about something.");
            Add(1, "asks if you have seen his dogs.");
            Add(1, "tells you to get off his land.");
            Add(1, "mumbles something about mushrooms.");
        }
    }
}

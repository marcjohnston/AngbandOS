namespace AngbandOS.Core.WeightedRandoms
{
    internal class ShopKeeperLessThanGuessComments : WeightedRandom<string>
    {
        public ShopKeeperLessThanGuessComments()
        {
            Add(1, "Damn!", "You bastard!", "The shopkeeper curses at you.", "The shopkeeper glares at you.");
        }
    }
}

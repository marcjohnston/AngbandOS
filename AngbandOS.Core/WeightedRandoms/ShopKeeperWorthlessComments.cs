namespace AngbandOS.Core.WeightedRandoms
{
    internal class ShopKeeperWorthlessComments : WeightedRandom<string>
    {
        public ShopKeeperWorthlessComments()
        {
            Add(1, "Arrgghh!", "You bastard!", "You hear someone sobbing...", "The shopkeeper howls in agony!");
        }
    }
}

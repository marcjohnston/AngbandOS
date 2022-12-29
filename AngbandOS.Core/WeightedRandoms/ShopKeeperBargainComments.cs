namespace AngbandOS.Core.WeightedRandoms
{
    internal class ShopKeeperBargainComments : WeightedRandom<string>
    {
        public ShopKeeperBargainComments()
        {
            Add(1, "Yipee!", "I think I'll retire!", "The shopkeeper jumps for joy.", "The shopkeeper smiles gleefully.");
        }
    }
}

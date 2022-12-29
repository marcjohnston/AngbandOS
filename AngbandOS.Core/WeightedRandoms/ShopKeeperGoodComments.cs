namespace AngbandOS.Core.WeightedRandoms
{
    internal class ShopKeeperGoodComments : WeightedRandom<string>
    {
        public ShopKeeperGoodComments()
        {
            Add(1, "Cool!", "You've made my day!", "The shopkeeper giggles.", "The shopkeeper laughs loudly.");
        }
    }
}

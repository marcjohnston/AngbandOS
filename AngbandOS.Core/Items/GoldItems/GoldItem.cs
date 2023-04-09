namespace AngbandOS.Core.Items
{
    [Serializable]
    internal abstract class GoldItem : Item
    {
        public GoldItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass)
        {
            int cost = ItemFactory.Cost;
            TypeSpecificValue = cost + (8 * Program.Rng.DieRoll(cost)) + Program.Rng.DieRoll(8);
        }
        public override int PackSort => 0;
    }
}
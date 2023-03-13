namespace AngbandOS.Core.Items
{
    [Serializable]
    internal abstract class GoldItem : Item
    {
        public GoldItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass)
        {
            int cost = BaseItemCategory.Cost;
            TypeSpecificValue = cost + (8 * Program.Rng.DieRoll(cost)) + Program.Rng.DieRoll(8);
        }
    }
}
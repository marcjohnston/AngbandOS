namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class FoodItem : Item
    {
        public FoodItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
        public override int PackSort => 9;
    }
}
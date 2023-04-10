namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class RodItem : Item
    {
        public RodItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
        protected override bool FactoryCanAbsorbItem(Item other)
        {
            if (TypeSpecificValue != other.TypeSpecificValue)
            {
                return false;
            }
            return true;
        }
    }
}
namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class BoltAmmunitionItem : AmmunitionItem
    {
        public BoltAmmunitionItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
    }
}
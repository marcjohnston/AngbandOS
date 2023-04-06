namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class AmmunitionItem : Item
    {
        public AmmunitionItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
        public override bool IdentityCanBeSensed => true;
    }
}
namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class ShotAmmunitionItem : AmmunitionItem
    {
        public ShotAmmunitionItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
        public override int PackSort => 35;
    }
}
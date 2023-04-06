namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class ArrowAmmunitionItem : AmmunitionItem
    {
        public override int PackSort => 34;
        public ArrowAmmunitionItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
    }
}
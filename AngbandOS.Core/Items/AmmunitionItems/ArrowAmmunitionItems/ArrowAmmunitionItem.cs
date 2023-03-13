namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class ArrowAmmunitionItem : AmmunitionItem
    {
        public ArrowAmmunitionItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
    }
}
namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class ShieldArmorItem : ArmourItem
    {
        public ShieldArmorItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
    }
}
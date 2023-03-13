namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class SoftArmorItem : ArmourItem
    {
        public SoftArmorItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
    }
}
namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class HardArmorItem : ArmourItem
    {
        public HardArmorItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
    }
}
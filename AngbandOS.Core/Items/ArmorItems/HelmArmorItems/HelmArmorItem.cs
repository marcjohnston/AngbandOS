namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class HelmArmorItem : ArmourItem
    {
        public HelmArmorItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
    }
}
namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class CrownArmorItem : ArmourItem
    {
        public CrownArmorItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
    }
}
namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class CloakArmorItem : ArmourItem
    {
        public CloakArmorItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
    }
}
namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class BootsItem : ArmourItem
    {
        public BootsItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
    }
}
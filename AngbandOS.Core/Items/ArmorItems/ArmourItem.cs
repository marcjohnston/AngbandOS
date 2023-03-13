namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class ArmourItem : Item
    {
        public ArmourItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
    }
}
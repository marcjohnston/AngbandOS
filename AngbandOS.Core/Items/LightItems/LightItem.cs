namespace AngbandOS.Core.Items
{
[Serializable]
    internal abstract class LightItem : ArmourItem
    {
        public LightItem(SaveGame saveGame, ItemClass itemClass) : base(saveGame, itemClass) { }
    }
}
namespace AngbandOS.Core.Items;

[Serializable]
internal abstract class JunkItem : Item
{
    public JunkItem(SaveGame saveGame, ItemFactory itemClass) : base(saveGame, itemClass) { }
    public override int PercentageBreakageChance => 100;
}
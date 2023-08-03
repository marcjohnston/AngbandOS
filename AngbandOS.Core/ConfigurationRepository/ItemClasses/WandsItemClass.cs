namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class WandsItemClass : ItemClass
{
    private WandsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Wands";
}
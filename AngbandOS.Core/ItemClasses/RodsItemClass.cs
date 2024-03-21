namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class RodsItemClass : ItemClass
{
    private RodsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Name => "Rod";
}
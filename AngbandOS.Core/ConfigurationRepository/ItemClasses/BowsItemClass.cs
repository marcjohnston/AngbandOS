namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class BowsItemClass : ItemClass
{
    private BowsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Bows";
}
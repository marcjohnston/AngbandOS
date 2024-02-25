namespace AngbandOS.Core.ItemClasses;

[Serializable]
internal class ChestsItemClass : ItemClass
{
    private ChestsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Name => "Chest";
    public override string Description => Pluralize(Name);
}
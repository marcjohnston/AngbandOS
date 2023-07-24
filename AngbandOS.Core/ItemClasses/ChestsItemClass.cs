[Serializable]
internal class ChestsItemClass : ItemClass
{
    private ChestsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Chests";
}
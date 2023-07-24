[Serializable]
internal class SwordsItemClass : ItemClass
{
    private SwordsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Swords";
}
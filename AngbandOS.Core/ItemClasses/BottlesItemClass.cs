[Serializable]
internal class BottlesItemClass : ItemClass
{
    private BottlesItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Bottles";
}
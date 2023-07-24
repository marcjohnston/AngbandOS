[Serializable]
internal class RingsItemClass : ItemClass
{
    private RingsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Rings";
}
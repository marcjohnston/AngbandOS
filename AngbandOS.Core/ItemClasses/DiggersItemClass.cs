[Serializable]
internal class DiggersItemClass : ItemClass
{
    private DiggersItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Diggers";
}
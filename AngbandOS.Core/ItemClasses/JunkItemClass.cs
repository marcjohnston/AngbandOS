[Serializable]
internal class JunkItemClass : ItemClass
{
    private JunkItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Junk";
}
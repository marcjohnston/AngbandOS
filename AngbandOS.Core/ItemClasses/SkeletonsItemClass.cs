[Serializable]
internal class SkeletonsItemClass : ItemClass
{
    private SkeletonsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Skeletons";
}
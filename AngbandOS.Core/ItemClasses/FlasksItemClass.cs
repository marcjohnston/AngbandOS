[Serializable]
internal class FlasksItemClass : ItemClass
{
    private FlasksItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Flasks";
}
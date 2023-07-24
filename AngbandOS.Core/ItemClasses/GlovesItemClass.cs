[Serializable]
internal class GlovesItemClass : ItemClass
{
    private GlovesItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Gloves";
}
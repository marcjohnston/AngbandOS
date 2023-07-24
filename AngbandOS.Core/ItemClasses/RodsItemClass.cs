[Serializable]
internal class RodsItemClass : ItemClass
{
    private RodsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Rods";
}
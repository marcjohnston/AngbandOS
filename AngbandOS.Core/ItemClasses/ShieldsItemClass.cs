[Serializable]
internal class ShieldsItemClass : ItemClass
{
    private ShieldsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Shields";
}
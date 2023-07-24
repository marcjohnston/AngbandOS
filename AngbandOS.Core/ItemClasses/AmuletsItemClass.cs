[Serializable]
internal class AmuletsItemClass : ItemClass
{
    private AmuletsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Amulets";
}
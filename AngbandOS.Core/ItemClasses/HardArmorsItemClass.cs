[Serializable]
internal class HardArmorsItemClass : ItemClass
{
    private HardArmorsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Hard Armours";
}
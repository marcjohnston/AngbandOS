[Serializable]
internal class SoftArmorsItemClass : ItemClass
{
    private SoftArmorsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Soft Armours";
}
[Serializable]
internal class PotionsItemClass : ItemClass
{
    private PotionsItemClass(SaveGame saveGame) : base(saveGame) { }
    public override string Description => "Potions";
}
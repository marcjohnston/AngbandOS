namespace AngbandOS.Core.Flavours;

[Serializable]
internal class BluePotionFlavour : PotionFlavour
{
    private BluePotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '!';
    public override Colour Colour => Colour.Blue;
    public override string Name => "Blue";
}

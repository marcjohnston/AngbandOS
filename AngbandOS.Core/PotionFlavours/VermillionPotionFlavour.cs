namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class VermillionPotionFlavour : PotionFlavour
{
    private VermillionPotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '!';
    public override Colour Colour => Colour.Red;
    public override string Name => "Vermillion";
}

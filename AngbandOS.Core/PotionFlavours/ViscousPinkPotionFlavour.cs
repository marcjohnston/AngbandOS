namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class ViscousPinkPotionFlavour : PotionFlavour
{
    private ViscousPinkPotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '!';
    public override Colour Colour => Colour.BrightRed;
    public override string Name => "Viscous Pink";
}

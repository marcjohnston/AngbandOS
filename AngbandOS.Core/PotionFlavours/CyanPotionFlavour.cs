namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class CyanPotionFlavour : PotionFlavour
{
    private CyanPotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '!';
    public override Colour Colour => Colour.BrightTurquoise;
    public override string Name => "Cyan";
}

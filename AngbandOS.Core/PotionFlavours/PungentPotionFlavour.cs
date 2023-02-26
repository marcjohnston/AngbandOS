namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class PungentPotionFlavour : PotionFlavour
{
    private PungentPotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '!';
    public override Colour Colour => Colour.Orange;
    public override string Name => "Pungent";
}

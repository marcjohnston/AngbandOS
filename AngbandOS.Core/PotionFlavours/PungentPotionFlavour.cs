namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class PungentPotionFlavour : PotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.Orange;
    public override string Name => "Pungent";
}

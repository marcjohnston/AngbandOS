namespace AngbandOS.Core;

[Serializable]
internal class CoagulatedCrimsonPotionFlavour : PotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.BrightRed;
    public override string Name => "Coagulated Crimson";
}

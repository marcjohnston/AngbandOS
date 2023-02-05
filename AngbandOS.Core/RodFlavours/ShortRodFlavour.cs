namespace AngbandOS.Core.RodFlavours;

[Serializable]
internal class ShortRodFlavour : RodFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.Green;
    public override string Name => "Short";
}

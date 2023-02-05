namespace AngbandOS.Core.RodFlavours;

[Serializable]
internal class IronRodFlavour : RodFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Iron";
}

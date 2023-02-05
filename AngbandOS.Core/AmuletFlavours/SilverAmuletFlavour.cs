namespace AngbandOS.Core.AmuletFlavours;

[Serializable]
internal class SilverAmuletFlavour : AmuletFlavour
{
    public override char Character => '"';
    public override Colour Colour => Colour.Silver;
    public override string Name => "Silver";
}

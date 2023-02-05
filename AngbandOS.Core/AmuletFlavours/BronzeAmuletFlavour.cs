namespace AngbandOS.Core.AmuletFlavours;

[Serializable]
internal class BronzeAmuletFlavour : AmuletFlavour
{
    public override char Character => '"';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "Bronze";
}

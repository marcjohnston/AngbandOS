namespace AngbandOS.Core;

[Serializable]
internal class CrystalAmuletFlavour : AmuletFlavour
{
    public override char Character => '"';
    public override Colour Colour => Colour.BrightRed;
    public override string Name => "Crystal";
}

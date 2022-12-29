namespace AngbandOS.Core;

[Serializable]
internal class GarnetAmuletFlavour : AmuletFlavour
{
    public override char Character => '"';
    public override Colour Colour => Colour.Red;
    public override string Name => "Garnet";
}

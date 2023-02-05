namespace AngbandOS.Core.RodFlavours;

[Serializable]
internal class RunedRodFlavour : RodFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.Red;
    public override string Name => "Runed";
}

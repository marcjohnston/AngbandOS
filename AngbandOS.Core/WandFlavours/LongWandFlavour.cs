namespace AngbandOS.Core.WandFlavours;

[Serializable]
internal class LongWandFlavour : WandFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.Green;
    public override string Name => "Long";
}

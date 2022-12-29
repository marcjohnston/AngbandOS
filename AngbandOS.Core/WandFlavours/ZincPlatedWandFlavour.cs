namespace AngbandOS.Core;

[Serializable]
internal class ZincPlatedWandFlavour : WandFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Zinc-Plated";
}

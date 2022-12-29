namespace AngbandOS.Core;

[Serializable]
internal class SilverPlatedWandFlavour : WandFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.Silver;
    public override string Name => "Silver-Plated";
}

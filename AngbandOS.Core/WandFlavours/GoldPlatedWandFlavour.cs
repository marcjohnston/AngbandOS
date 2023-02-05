namespace AngbandOS.Core.WandFlavours;

[Serializable]
internal class GoldPlatedWandFlavour : WandFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.Gold;
    public override string Name => "Gold-Plated";
}

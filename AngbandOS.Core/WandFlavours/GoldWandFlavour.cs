namespace AngbandOS.Core;

[Serializable]
internal class GoldWandFlavour : WandFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.Gold;
    public override string Name => "Gold";
}

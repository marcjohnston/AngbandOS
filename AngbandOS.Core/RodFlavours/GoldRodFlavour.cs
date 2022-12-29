namespace AngbandOS.Core;

[Serializable]
internal class GoldRodFlavour : RodFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.Gold;
    public override string Name => "Gold";
}

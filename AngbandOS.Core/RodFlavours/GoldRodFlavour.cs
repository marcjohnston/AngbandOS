namespace AngbandOS.Core.RodFlavours;

[Serializable]
internal class GoldRodFlavour : RodFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.Gold;
    public override string Name => "Gold";
}

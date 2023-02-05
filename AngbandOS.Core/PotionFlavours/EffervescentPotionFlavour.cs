namespace AngbandOS.Core.PotionFlavours;

[Serializable]
internal class EffervescentPotionFlavour : PotionFlavour
{
    public override char Character => '!';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "Effervescent";
}

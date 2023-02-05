namespace AngbandOS.Core.MushroomFlavours;

[Serializable]
internal class YellowMushroomFlavour : MushroomFlavour
{
    public override char Character => ',';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "Yellow";
}

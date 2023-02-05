namespace AngbandOS.Core.MushroomFlavours;

[Serializable]
internal class WhiteSpottedMushroomFlavour : MushroomFlavour
{
    public override char Character => ',';
    public override Colour Colour => Colour.Silver;
    public override string Name => "White Spotted";
}

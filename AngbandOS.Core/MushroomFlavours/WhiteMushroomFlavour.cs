namespace AngbandOS.Core;

[Serializable]
internal class WhiteMushroomFlavour : MushroomFlavour
{
    public override char Character => ',';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "White";
}

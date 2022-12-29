namespace AngbandOS.Core;

[Serializable]
internal class FurryMushroomFlavour : MushroomFlavour
{
    public override char Character => ',';
    public override Colour Colour => Colour.BrightOrange;
    public override string Name => "Furry";
}

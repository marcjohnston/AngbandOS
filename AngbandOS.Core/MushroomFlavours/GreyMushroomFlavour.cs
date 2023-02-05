namespace AngbandOS.Core.MushroomFlavours;

[Serializable]
internal class GreyMushroomFlavour : MushroomFlavour
{
    public override char Character => ',';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Grey";
}

namespace AngbandOS.Core.MushroomFlavours;

[Serializable]
internal class BlackMushroomFlavour : MushroomFlavour
{
    public override char Character => ',';
    public override Colour Colour => Colour.Black;
    public override string Name => "Black";
}

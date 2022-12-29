namespace AngbandOS.Core;

[Serializable]
internal class WrinkledMushroomFlavour : MushroomFlavour
{
    public override char Character => ',';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Wrinkled";
}

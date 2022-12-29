namespace AngbandOS.Core;

[Serializable]
internal class BrownMushroomFlavour : MushroomFlavour
{
    public override char Character => ',';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Brown";
}

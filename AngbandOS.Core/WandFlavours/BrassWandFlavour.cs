namespace AngbandOS.Core;

[Serializable]
internal class BrassWandFlavour : WandFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.Copper;
    public override string Name => "Brass";
}

namespace AngbandOS.Core.WandFlavours;

[Serializable]
internal class BrassWandFlavour : WandFlavour
{
    private BrassWandFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override Colour Colour => Colour.Copper;
    public override string Name => "Brass";
}

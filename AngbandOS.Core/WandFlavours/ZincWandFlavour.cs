namespace AngbandOS.Core.WandFlavours;

[Serializable]
internal class ZincWandFlavour : WandFlavour
{
    private ZincWandFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Zinc";
}

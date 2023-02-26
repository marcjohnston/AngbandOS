namespace AngbandOS.Core.WandFlavours;

[Serializable]
internal class ZincPlatedWandFlavour : WandFlavour
{
    private ZincPlatedWandFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Zinc-Plated";
}

namespace AngbandOS.Core.WandFlavours;

[Serializable]
internal class IronWandFlavour : WandFlavour
{
    private IronWandFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Iron";
}

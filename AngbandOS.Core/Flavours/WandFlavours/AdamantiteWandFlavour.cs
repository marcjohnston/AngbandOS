namespace AngbandOS.Core.Flavours;

[Serializable]
internal class AdamantiteWandFlavour : WandFlavour
{
    private AdamantiteWandFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override Colour Colour => Colour.Chartreuse;
    public override string Name => "Adamantite";
}

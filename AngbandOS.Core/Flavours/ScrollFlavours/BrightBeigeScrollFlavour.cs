namespace AngbandOS.Core.Flavours;

[Serializable]
internal class BrightBeigeScrollFlavour : BaseScrollFlavour
{
    private BrightBeigeScrollFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '?';
    public override Colour Colour => Colour.BrightBeige;
}

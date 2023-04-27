namespace AngbandOS.Core.Flavours;

[Serializable]
internal class BeigeScrollFlavour : BaseScrollFlavour
{
    private BeigeScrollFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '?';
    public override Colour Colour => Colour.Beige;

    public override string Name => "Beige";
}

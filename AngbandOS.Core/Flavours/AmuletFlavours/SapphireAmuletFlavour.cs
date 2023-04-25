namespace AngbandOS.Core.Flavours;

[Serializable]
internal class SapphireAmuletFlavour : AmuletFlavour
{
    private SapphireAmuletFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '"';
    public override Colour Colour => Colour.Blue;
    public override string Name => "Sapphire";
}

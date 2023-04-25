namespace AngbandOS.Core.Flavours;

[Serializable]
internal class ObsidianRingFlavour : RingFlavour
{
    private ObsidianRingFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '=';
    public override Colour Colour => Colour.Black;
    public override string Name => "Obsidian";
}

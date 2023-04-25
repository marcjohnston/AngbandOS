namespace AngbandOS.Core.Flavours;

[Serializable]
internal class ZincRodFlavour : RodFlavour
{
    private ZincRodFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override string Name => "Zinc";
}

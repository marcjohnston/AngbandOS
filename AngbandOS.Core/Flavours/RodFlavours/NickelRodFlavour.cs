namespace AngbandOS.Core.Flavours;

[Serializable]
internal class NickelRodFlavour : RodFlavour
{
    private NickelRodFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override string Name => "Nickel";
}

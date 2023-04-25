namespace AngbandOS.Core.Flavours;

[Serializable]
internal class TinPlatedRodFlavour : RodFlavour
{
    private TinPlatedRodFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override string Name => "Tin-Plated";
}

namespace AngbandOS.Core.Flavours;

[Serializable]
internal class SteelPlatedRodFlavour : RodFlavour
{
    private SteelPlatedRodFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override string Name => "Steel-Plated";
}

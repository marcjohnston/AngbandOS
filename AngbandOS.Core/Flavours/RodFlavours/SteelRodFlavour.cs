namespace AngbandOS.Core.Flavours;

[Serializable]
internal class SteelRodFlavour : RodFlavour
{
    private SteelRodFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override string Name => "Steel";
}

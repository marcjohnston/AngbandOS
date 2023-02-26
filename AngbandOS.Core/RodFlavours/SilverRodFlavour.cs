namespace AngbandOS.Core.RodFlavours;

[Serializable]
internal class SilverRodFlavour : RodFlavour
{
    private SilverRodFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override string Name => "Silver";
}

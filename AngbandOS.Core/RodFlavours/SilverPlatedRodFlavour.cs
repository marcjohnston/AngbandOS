namespace AngbandOS.Core.RodFlavours;

[Serializable]
internal class SilverPlatedRodFlavour : RodFlavour
{
    private SilverPlatedRodFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override string Name => "Silver-Plated";
}

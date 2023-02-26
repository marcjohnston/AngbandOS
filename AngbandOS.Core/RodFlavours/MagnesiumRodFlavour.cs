namespace AngbandOS.Core.RodFlavours;

[Serializable]
internal class MagnesiumRodFlavour : RodFlavour
{
    private MagnesiumRodFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override string Name => "Magnesium";
}

namespace AngbandOS.Core.RodFlavours;

[Serializable]
internal class TitaniumRodFlavour : RodFlavour
{
    private TitaniumRodFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override string Name => "Titanium";
}

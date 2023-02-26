namespace AngbandOS.Core.RodFlavours;

[Serializable]
internal class TungstenRodFlavour : RodFlavour
{
    private TungstenRodFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override string Name => "Tungsten";
}

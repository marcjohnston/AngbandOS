namespace AngbandOS.Core.RodFlavours;

[Serializable]
internal class ZincPlatedRodFlavour : RodFlavour
{
    private ZincPlatedRodFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override string Name => "Zinc-Plated";
}

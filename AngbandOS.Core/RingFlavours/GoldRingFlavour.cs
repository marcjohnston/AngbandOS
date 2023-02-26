namespace AngbandOS.Core.RingFlavours;

[Serializable]
internal class GoldRingFlavour : RingFlavour
{
    private GoldRingFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '=';
    public override Colour Colour => Colour.Gold;
    public override string Name => "Gold";
}

namespace AngbandOS.Core.Flavours;

[Serializable]
internal class GoldPlatedRodFlavour : RodFlavour
{
    private GoldPlatedRodFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override Colour Colour => Colour.Gold;
    public override string Name => "Gold-Plated";
}

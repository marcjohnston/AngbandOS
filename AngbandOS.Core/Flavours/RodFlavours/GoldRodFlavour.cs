namespace AngbandOS.Core.Flavours;

[Serializable]
internal class GoldRodFlavour : RodFlavour
{
    private GoldRodFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override Colour Colour => Colour.Gold;
    public override string Name => "Gold";
}
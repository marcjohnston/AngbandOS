namespace AngbandOS.Core.WandFlavours;

[Serializable]
internal class GoldPlatedWandFlavour : WandFlavour
{
    private GoldPlatedWandFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override Colour Colour => Colour.Gold;
    public override string Name => "Gold-Plated";
}

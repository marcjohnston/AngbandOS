namespace AngbandOS.Core.WandFlavours;

[Serializable]
internal class GoldWandFlavour : WandFlavour
{
    private GoldWandFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override Colour Colour => Colour.Gold;
    public override string Name => "Gold";
}

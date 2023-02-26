namespace AngbandOS.Core.WandFlavours;

[Serializable]
internal class MagnesiumWandFlavour : WandFlavour
{
    private MagnesiumWandFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '-';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Magnesium";
}

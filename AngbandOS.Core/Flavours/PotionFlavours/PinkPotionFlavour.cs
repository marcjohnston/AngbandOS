namespace AngbandOS.Core.Flavours;

[Serializable]
internal class PinkPotionFlavour : PotionFlavour
{
    private PinkPotionFlavour(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '!';
    public override Colour Colour => Colour.Pink;
    public override string Name => "Pink";
}

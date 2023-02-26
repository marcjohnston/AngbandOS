namespace AngbandOS.Core.Animations;

[Serializable]
internal class GoldExpandAnimation : Animation
{
    private GoldExpandAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.Gold;
    public override string Name => "GoldExpand";
    public override Colour AlternateColour => Colour.Gold;
    public override string Sequence => @"·oO";
}

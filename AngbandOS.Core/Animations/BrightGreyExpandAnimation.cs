namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightGreyExpandAnimation : Animation
{
    private BrightGreyExpandAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightGrey;
    public override string Name => "BrightGreyExpand";
    public override Colour AlternateColour => Colour.BrightGrey;
    public override string Sequence => @"·oO";
}

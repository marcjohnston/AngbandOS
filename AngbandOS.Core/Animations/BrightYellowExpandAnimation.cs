namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightYellowExpandAnimation : Animation
{
    private BrightYellowExpandAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightYellow;
    public override string Name => "BrightYellowExpand";
    public override Colour AlternateColour => Colour.BrightYellow;
    public override string Sequence => @"·oO";
}

namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightGreenExpandAnimation : Animation
{
    private BrightGreenExpandAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightGreen;
    public override string Name => "BrightGreenExpand";
    public override Colour AlternateColour => Colour.BrightGreen;
    public override string Sequence => @"·oO";
}

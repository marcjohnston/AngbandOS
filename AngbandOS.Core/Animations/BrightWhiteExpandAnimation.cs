namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightWhiteExpandAnimation : Animation
{
    private BrightWhiteExpandAnimation(SaveGame saveGame) : base(saveGame) { } // This object is a singleton.
    public override char Character => '*';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "BrightWhiteExpand";
    public override Colour AlternateColour => Colour.BrightWhite;
    public override string Sequence => @"·oO";
}

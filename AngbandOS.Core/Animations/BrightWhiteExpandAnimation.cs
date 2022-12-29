namespace AngbandOS.Core;

[Serializable]
internal class BrightWhiteExpandAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "BrightWhiteExpand";
    public override Colour AlternateColour => Colour.BrightWhite;
    public override string Sequence => @"·oO";
}

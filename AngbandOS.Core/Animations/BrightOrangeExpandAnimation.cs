namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightOrangeExpandAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightOrange;
    public override string Name => "BrightOrangeExpand";
    public override Colour AlternateColour => Colour.BrightOrange;
    public override string Sequence => @"·oO";
}

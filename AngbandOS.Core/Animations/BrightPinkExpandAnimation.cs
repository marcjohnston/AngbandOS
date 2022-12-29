namespace AngbandOS.Core;

[Serializable]
internal class BrightPinkExpandAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightPink;
    public override string Name => "BrightPinkExpand";
    public override Colour AlternateColour => Colour.BrightPink;
    public override string Sequence => @"·oO";
}

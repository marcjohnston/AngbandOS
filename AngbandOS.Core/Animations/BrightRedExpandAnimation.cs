namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightRedExpandAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightRed;
    public override string Name => "BrightRedExpand";
    public override Colour AlternateColour => Colour.BrightRed;
    public override string Sequence => @"·oO";
}

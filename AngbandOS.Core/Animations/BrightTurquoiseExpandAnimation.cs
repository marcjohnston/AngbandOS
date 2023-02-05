namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightTurquoiseExpandAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightTurquoise;
    public override string Name => "BrightTurquoiseExpand";
    public override Colour AlternateColour => Colour.BrightTurquoise;
    public override string Sequence => @"·oO";
}

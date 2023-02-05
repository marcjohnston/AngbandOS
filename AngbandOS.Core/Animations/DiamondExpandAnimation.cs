namespace AngbandOS.Core.Animations;

[Serializable]
internal class DiamondExpandAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Diamond;
    public override string Name => "DiamondExpand";
    public override Colour AlternateColour => Colour.Diamond;
    public override string Sequence => @"·oO";
}

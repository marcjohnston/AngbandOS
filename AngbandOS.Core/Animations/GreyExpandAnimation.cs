namespace AngbandOS.Core.Animations;

[Serializable]
internal class GreyExpandAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Grey;
    public override string Name => "GreyExpand";
    public override Colour AlternateColour => Colour.Grey;
    public override string Sequence => @"·oO";
}

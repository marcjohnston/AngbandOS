namespace AngbandOS.Core.Animations;

[Serializable]
internal class BlackExpandAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Black;
    public override string Name => "BlackExpand";
    public override Colour AlternateColour => Colour.Black;
    public override string Sequence => @"·oO";
}

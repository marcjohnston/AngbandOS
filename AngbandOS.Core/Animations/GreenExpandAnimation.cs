namespace AngbandOS.Core;

[Serializable]
internal class GreenExpandAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Green;
    public override string Name => "GreenExpand";
    public override Colour AlternateColour => Colour.Green;
    public override string Sequence => @"·oO";
}

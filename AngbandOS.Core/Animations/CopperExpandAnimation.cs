namespace AngbandOS.Core.Animations;

[Serializable]
internal class CopperExpandAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Copper;
    public override string Name => "CopperExpand";
    public override Colour AlternateColour => Colour.Copper;
    public override string Sequence => @"·oO";
}

namespace AngbandOS.Core.Animations;

[Serializable]
internal class GoldExpandAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Gold;
    public override string Name => "GoldExpand";
    public override Colour AlternateColour => Colour.Gold;
    public override string Sequence => @"·oO";
}

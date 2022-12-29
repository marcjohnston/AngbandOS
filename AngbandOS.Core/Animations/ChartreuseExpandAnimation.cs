namespace AngbandOS.Core;

[Serializable]
internal class ChartreuseExpandAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Chartreuse;
    public override string Name => "ChartreuseExpand";
    public override Colour AlternateColour => Colour.Chartreuse;
    public override string Sequence => @"·oO";
}

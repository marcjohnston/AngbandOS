namespace AngbandOS.Core;

[Serializable]
internal class BrownExpandAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Brown;
    public override string Name => "BrownExpand";
    public override Colour AlternateColour => Colour.Brown;
    public override string Sequence => @"·oO";
}

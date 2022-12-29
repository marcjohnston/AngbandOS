namespace AngbandOS.Core;

[Serializable]
internal class BlueExpandAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Blue;
    public override string Name => "BlueExpand";
    public override Colour AlternateColour => Colour.Blue;
    public override string Sequence => @"·oO";
}

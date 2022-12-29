namespace AngbandOS.Core;

[Serializable]
internal class BrightBrownCloudAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "BrightBrownCloud";
    public override Colour AlternateColour => Colour.BrightBrown;
    public override string Sequence => @"+*+*+*+";
}

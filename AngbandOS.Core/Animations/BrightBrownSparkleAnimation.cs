namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightBrownSparkleAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "BrightBrownSparkle";
    public override Colour AlternateColour => Colour.BrightBrown;
    public override string Sequence => @"·+·x·+·";
}

namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightWhiteSparkleAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "BrightWhiteSparkle";
    public override Colour AlternateColour => Colour.BrightWhite;
    public override string Sequence => @"·+·x·+·";
}

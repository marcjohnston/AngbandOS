namespace AngbandOS.Core;

[Serializable]
internal class BrightBlueSparkleAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "BrightBlueSparkle";
    public override Colour AlternateColour => Colour.BrightBlue;
    public override string Sequence => @"·+·x·+·";
}

namespace AngbandOS.Core;

[Serializable]
internal class BrightPurpleSparkleAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightPurple;
    public override string Name => "BrightPurpleSparkle";
    public override Colour AlternateColour => Colour.BrightPurple;
    public override string Sequence => @"·+·x·+·";
}

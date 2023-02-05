namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightPinkSparkleAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightPink;
    public override string Name => "BrightPinkSparkle";
    public override Colour AlternateColour => Colour.BrightPink;
    public override string Sequence => @"·+·x·+·";
}

namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightTurquoiseSparkleAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightTurquoise;
    public override string Name => "BrightTurquoiseSparkle";
    public override Colour AlternateColour => Colour.BrightTurquoise;
    public override string Sequence => @"·+·x·+·";
}

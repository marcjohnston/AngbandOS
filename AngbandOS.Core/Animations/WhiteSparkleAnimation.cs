namespace AngbandOS.Core.Animations;

[Serializable]
internal class WhiteSparkleAnimation : Animation
{
    public override char Character => '*';
    public override string Name => "WhiteSparkle";
    public override string Sequence => @"·+·x·+·";
    public override Colour Colour => Colour.White;
    public override Colour AlternateColour => Colour.White;
}

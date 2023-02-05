namespace AngbandOS.Core.Animations;

[Serializable]
internal class BlackSparkleAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Black;
    public override string Name => "BlackSparkle";
    public override Colour AlternateColour => Colour.Black;
    public override string Sequence => @"·+·x·+·";
}

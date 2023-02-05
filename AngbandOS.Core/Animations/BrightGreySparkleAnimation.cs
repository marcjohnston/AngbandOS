namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightGreySparkleAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightGrey;
    public override string Name => "BrightGreySparkle";
    public override Colour AlternateColour => Colour.BrightGrey;
    public override string Sequence => @"·+·x·+·";
}

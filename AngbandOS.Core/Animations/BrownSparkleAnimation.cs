namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrownSparkleAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Brown;
    public override string Name => "BrownSparkle";
    public override Colour AlternateColour => Colour.Brown;
    public override string Sequence => @"·+·x·+·";
}

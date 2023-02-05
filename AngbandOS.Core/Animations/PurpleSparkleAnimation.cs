namespace AngbandOS.Core.Animations;

[Serializable]
internal class PurpleSparkleAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Purple;
    public override string Name => "PurpleSparkle";
    public override Colour AlternateColour => Colour.Purple;
    public override string Sequence => @"·+·x·+·";
}

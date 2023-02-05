namespace AngbandOS.Core.Animations;

[Serializable]
internal class BlueSparkleAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Blue;
    public override string Name => "BlueSparkle";
    public override Colour AlternateColour => Colour.Blue;
    public override string Sequence => @"·+·x·+·";
}

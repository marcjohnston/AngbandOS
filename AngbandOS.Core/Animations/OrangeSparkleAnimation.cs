namespace AngbandOS.Core;

[Serializable]
internal class OrangeSparkleAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Orange;
    public override string Name => "OrangeSparkle";
    public override Colour AlternateColour => Colour.Orange;
    public override string Sequence => @"·+·x·+·";
}

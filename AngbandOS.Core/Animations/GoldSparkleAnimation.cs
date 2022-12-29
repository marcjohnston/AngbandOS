namespace AngbandOS.Core;

[Serializable]
internal class GoldSparkleAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Gold;
    public override string Name => "GoldSparkle";
    public override Colour AlternateColour => Colour.Gold;
    public override string Sequence => @"·+·x·+·";
}

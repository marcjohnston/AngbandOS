namespace AngbandOS.Core;

[Serializable]
internal class BeigeControlAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Beige;
    public override string Name => "BeigeControl";
    public override Colour AlternateColour => Colour.BrightBeige;
    public override string Sequence => @"!!!!";
}

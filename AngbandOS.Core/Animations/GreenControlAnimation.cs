namespace AngbandOS.Core.Animations;

[Serializable]
internal class GreenControlAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Green;
    public override string Name => "GreenControl";
    public override Colour AlternateColour => Colour.BrightGreen;
    public override string Sequence => @"!!!!";
}

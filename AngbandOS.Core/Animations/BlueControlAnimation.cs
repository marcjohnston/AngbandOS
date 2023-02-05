namespace AngbandOS.Core.Animations;

[Serializable]
internal class BlueControlAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Blue;
    public override string Name => "BlueControl";
    public override Colour AlternateColour => Colour.BrightBlue;
    public override string Sequence => @"!!!!";
}

namespace AngbandOS.Core;

[Serializable]
internal class WhiteControlAnimation : Animation
{
    public override char Character => '*';
    public override string Name => "WhiteControl";
    public override Colour AlternateColour => Colour.BrightWhite;
    public override string Sequence => @"!!!!";
    public override Colour Colour => Colour.White;
}

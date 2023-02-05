namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightWhiteSwirlAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "BrightWhiteSwirl";
    public override Colour AlternateColour => Colour.BrightWhite;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}

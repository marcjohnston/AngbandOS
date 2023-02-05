namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightYellowSwirlAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightYellow;
    public override string Name => "BrightYellowSwirl";
    public override Colour AlternateColour => Colour.BrightYellow;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}

namespace AngbandOS.Core;

[Serializable]
internal class BrightGreenSwirlAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightGreen;
    public override string Name => "BrightGreenSwirl";
    public override Colour AlternateColour => Colour.BrightGreen;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}

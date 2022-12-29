namespace AngbandOS.Core;

[Serializable]
internal class BrightBeigeSwirlAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightBeige;
    public override string Name => "BrightBeigeSwirl";
    public override Colour AlternateColour => Colour.BrightBeige;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}

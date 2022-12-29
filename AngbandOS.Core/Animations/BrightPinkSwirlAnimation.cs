namespace AngbandOS.Core;

[Serializable]
internal class BrightPinkSwirlAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightPink;
    public override string Name => "BrightPinkSwirl";
    public override Colour AlternateColour => Colour.BrightPink;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}

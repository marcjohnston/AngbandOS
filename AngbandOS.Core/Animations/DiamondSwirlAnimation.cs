namespace AngbandOS.Core;

[Serializable]
internal class DiamondSwirlAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Diamond;
    public override string Name => "DiamondSwirl";
    public override Colour AlternateColour => Colour.Diamond;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}

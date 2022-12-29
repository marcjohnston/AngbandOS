namespace AngbandOS.Core;

[Serializable]
internal class OrangeSwirlAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Orange;
    public override string Name => "OrangeSwirl";
    public override Colour AlternateColour => Colour.Orange;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}

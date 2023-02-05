namespace AngbandOS.Core.Animations;

[Serializable]
internal class RedSwirlAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Red;
    public override string Name => "RedSwirl";
    public override Colour AlternateColour => Colour.Red;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}

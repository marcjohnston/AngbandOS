namespace AngbandOS.Core.Animations;

[Serializable]
internal class BlueSwirlAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Blue;
    public override string Name => "BlueSwirl";
    public override Colour AlternateColour => Colour.Blue;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}

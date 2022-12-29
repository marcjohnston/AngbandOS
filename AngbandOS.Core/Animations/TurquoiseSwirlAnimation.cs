namespace AngbandOS.Core;

[Serializable]
internal class TurquoiseSwirlAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Turquoise;
    public override string Name => "TurquoiseSwirl";
    public override Colour AlternateColour => Colour.Turquoise;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}

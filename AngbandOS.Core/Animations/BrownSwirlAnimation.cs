namespace AngbandOS.Core;

[Serializable]
internal class BrownSwirlAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Brown;
    public override string Name => "BrownSwirl";
    public override Colour AlternateColour => Colour.Brown;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}

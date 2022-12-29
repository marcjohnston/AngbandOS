namespace AngbandOS.Core;

[Serializable]
internal class BrightGreySwirlAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightGrey;
    public override string Name => "BrightGreySwirl";
    public override Colour AlternateColour => Colour.BrightGrey;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}

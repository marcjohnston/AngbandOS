namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightYellowCloudAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightYellow;
    public override string Name => "BrightYellowCloud";
    public override Colour AlternateColour => Colour.BrightYellow;
    public override string Sequence => @"+*+*+*+";
}

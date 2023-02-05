namespace AngbandOS.Core.Animations;

[Serializable]
internal class YellowCloudAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "YellowCloud";
    public override Colour AlternateColour => Colour.Yellow;
    public override string Sequence => @"+*+*+*+";
}

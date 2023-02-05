namespace AngbandOS.Core.Animations;

[Serializable]
internal class GreyCloudAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Grey;
    public override string Name => "GreyCloud";
    public override Colour AlternateColour => Colour.Grey;
    public override string Sequence => @"+*+*+*+";
}

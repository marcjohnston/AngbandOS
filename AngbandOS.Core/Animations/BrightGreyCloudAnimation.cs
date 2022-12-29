namespace AngbandOS.Core;

[Serializable]
internal class BrightGreyCloudAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightGrey;
    public override string Name => "BrightGreyCloud";
    public override Colour AlternateColour => Colour.BrightGrey;
    public override string Sequence => @"+*+*+*+";
}

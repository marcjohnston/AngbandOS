namespace AngbandOS.Core;

[Serializable]
internal class WhiteCloudAnimation : Animation
{
    public override char Character => '*';
    public override string Name => "WhiteCloud";
    public override string Sequence => @"+*+*+*+";
    public override Colour Colour => Colour.White;
    public override Colour AlternateColour => Colour.White;
}

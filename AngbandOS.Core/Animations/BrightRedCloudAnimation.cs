namespace AngbandOS.Core.Animations;

[Serializable]
internal class BrightRedCloudAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightRed;
    public override string Name => "BrightRedCloud";
    public override Colour AlternateColour => Colour.BrightRed;
    public override string Sequence => @"+*+*+*+";
}

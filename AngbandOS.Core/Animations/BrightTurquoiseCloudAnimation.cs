namespace AngbandOS.Core;

[Serializable]
internal class BrightTurquoiseCloudAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightTurquoise;
    public override string Name => "BrightTurquoiseCloud";
    public override Colour AlternateColour => Colour.BrightTurquoise;
    public override string Sequence => @"+*+*+*+";
}

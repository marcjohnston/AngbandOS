namespace AngbandOS.Core;

[Serializable]
internal class BeigeCloudAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Beige;
    public override string Name => "BeigeCloud";
    public override Colour AlternateColour => Colour.Beige;
    public override string Sequence => @"+*+*+*+";
}

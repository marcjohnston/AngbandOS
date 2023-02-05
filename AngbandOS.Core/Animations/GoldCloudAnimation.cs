namespace AngbandOS.Core.Animations;

[Serializable]
internal class GoldCloudAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Gold;
    public override string Name => "GoldCloud";
    public override Colour AlternateColour => Colour.Gold;
    public override string Sequence => @"+*+*+*+";
}

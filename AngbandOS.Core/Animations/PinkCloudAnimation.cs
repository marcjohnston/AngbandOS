namespace AngbandOS.Core.Animations;

[Serializable]
internal class PinkCloudAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Pink;
    public override string Name => "PinkCloud";
    public override Colour AlternateColour => Colour.Pink;
    public override string Sequence => @"+*+*+*+";
}

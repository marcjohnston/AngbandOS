namespace AngbandOS.Core.Animations;

[Serializable]
internal class PurpleCloudAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Purple;
    public override string Name => "PurpleCloud";
    public override Colour AlternateColour => Colour.Purple;
    public override string Sequence => @"+*+*+*+";
}

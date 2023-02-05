namespace AngbandOS.Core.Animations;

[Serializable]
internal class GreyControlAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Grey;
    public override string Name => "GreyControl";
    public override Colour AlternateColour => Colour.BrightGrey;
    public override string Sequence => @"!!!!";
}

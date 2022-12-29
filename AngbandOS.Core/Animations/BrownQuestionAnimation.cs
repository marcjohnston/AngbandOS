namespace AngbandOS.Core;

[Serializable]
internal class BrownQuestionAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Brown;
    public override string Name => "BrownQuestion";
    public override Colour AlternateColour => Colour.BrightBrown;
    public override string Sequence => @"??????";
}

namespace AngbandOS.Core;

[Serializable]
internal class BeigeQuestionAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Beige;
    public override string Name => "BeigeQuestion";
    public override Colour AlternateColour => Colour.BrightBeige;
    public override string Sequence => @"??????";
}

using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BlackQuestionAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Black;
    public override string Name => "BlackQuestion";
    public override Colour AlternateColour => Colour.Grey;
    public override string Sequence => @"??????";
}

using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrownQuestionAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Brown;
    public override string Name => "BrownQuestion";
    public override Colour AlternateColour => Colour.BrightBrown;
    public override string Sequence => @"??????";
}

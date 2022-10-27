using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class GreyControlAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Grey;
    public override string Name => "GreyControl";
    public override Colour AlternateColour => Colour.BrightGrey;
    public override string Sequence => @"!!!!";
}

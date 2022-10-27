using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightWhiteSwirlAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "BrightWhiteSwirl";
    public override Colour AlternateColour => Colour.BrightWhite;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}

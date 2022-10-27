using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightYellowSwirlAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightYellow;
    public override string Name => "BrightYellowSwirl";
    public override Colour AlternateColour => Colour.BrightYellow;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}

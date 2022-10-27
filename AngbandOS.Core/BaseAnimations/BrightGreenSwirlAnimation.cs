using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightGreenSwirlAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightGreen;
    public override string Name => "BrightGreenSwirl";
    public override Colour AlternateColour => Colour.BrightGreen;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}

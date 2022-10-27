using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightRedSwirlAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightRed;
    public override string Name => "BrightRedSwirl";
    public override Colour AlternateColour => Colour.BrightRed;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}

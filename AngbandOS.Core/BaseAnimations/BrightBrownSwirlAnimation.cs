using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightBrownSwirlAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightBrown;
    public override string Name => "BrightBrownSwirl";
    public override Colour AlternateColour => Colour.BrightBrown;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}

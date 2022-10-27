using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class DiamondSwirlAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Diamond;
    public override string Name => "DiamondSwirl";
    public override Colour AlternateColour => Colour.Diamond;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}

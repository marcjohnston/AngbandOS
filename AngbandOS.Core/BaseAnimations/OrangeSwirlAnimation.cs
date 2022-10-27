using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class OrangeSwirlAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Orange;
    public override string Name => "OrangeSwirl";
    public override Colour AlternateColour => Colour.Orange;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}

using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class PinkSwirlAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Pink;
    public override string Name => "PinkSwirl";
    public override Colour AlternateColour => Colour.Pink;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}

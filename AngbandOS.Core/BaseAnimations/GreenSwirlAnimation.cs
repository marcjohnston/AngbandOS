using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class GreenSwirlAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Green;
    public override string Name => "GreenSwirl";
    public override Colour AlternateColour => Colour.Green;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}

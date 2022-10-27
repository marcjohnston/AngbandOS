using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class RedSwirlAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Red;
    public override string Name => "RedSwirl";
    public override Colour AlternateColour => Colour.Red;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}

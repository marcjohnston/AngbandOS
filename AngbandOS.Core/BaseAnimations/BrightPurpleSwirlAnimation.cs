using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightPurpleSwirlAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightPurple;
    public override string Name => "BrightPurpleSwirl";
    public override Colour AlternateColour => Colour.BrightPurple;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}

using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightTurquoiseSwirlAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightTurquoise;
    public override string Name => "BrightTurquoiseSwirl";
    public override Colour AlternateColour => Colour.BrightTurquoise;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}

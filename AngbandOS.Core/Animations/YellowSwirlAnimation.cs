using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class YellowSwirlAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "YellowSwirl";
    public override Colour AlternateColour => Colour.Yellow;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}

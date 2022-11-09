using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class GreySwirlAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Grey;
    public override string Name => "GreySwirl";
    public override Colour AlternateColour => Colour.Grey;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}

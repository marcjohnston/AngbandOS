using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class CopperSwirlAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Copper;
    public override string Name => "CopperSwirl";
    public override Colour AlternateColour => Colour.Copper;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}

using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BlackSwirlAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Black;
    public override string Name => "BlackSwirl";
    public override Colour AlternateColour => Colour.Black;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}

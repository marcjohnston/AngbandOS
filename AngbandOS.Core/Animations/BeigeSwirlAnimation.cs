using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BeigeSwirlAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Beige;
    public override string Name => "BeigeSwirl";
    public override Colour AlternateColour => Colour.Beige;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}

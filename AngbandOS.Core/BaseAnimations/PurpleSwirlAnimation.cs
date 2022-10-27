using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class PurpleSwirlAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Purple;
    public override string Name => "PurpleSwirl";
    public override Colour AlternateColour => Colour.Purple;
    public override string Sequence => @"|/-\|/-\|/-\|/-\";
}

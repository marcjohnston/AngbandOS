using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BlackControlAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Black;
    public override string Name => "BlackControl";
    public override Colour AlternateColour => Colour.Grey;
    public override string Sequence => @"!!!!";
}

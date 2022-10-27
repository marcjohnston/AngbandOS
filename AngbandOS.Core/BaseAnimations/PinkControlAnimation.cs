using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class PinkControlAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Pink;
    public override string Name => "PinkControl";
    public override Colour AlternateColour => Colour.BrightPink;
    public override string Sequence => @"!!!!";
}

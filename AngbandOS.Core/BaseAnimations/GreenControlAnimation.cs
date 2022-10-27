using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class GreenControlAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Green;
    public override string Name => "GreenControl";
    public override Colour AlternateColour => Colour.BrightGreen;
    public override string Sequence => @"!!!!";
}

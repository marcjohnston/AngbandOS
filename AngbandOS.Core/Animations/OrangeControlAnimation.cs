using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class OrangeControlAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Orange;
    public override string Name => "OrangeControl";
    public override Colour AlternateColour => Colour.BrightOrange;
    public override string Sequence => @"!!!!";
}

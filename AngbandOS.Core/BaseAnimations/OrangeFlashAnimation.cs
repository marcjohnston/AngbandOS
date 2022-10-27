using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class OrangeFlashAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Orange;
    public override string Name => "OrangeFlash";
    public override Colour AlternateColour => Colour.BrightOrange;
    public override string Sequence => @"********";
}

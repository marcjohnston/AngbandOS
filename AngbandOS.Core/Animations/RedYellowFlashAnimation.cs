using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class RedYellowFlashAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightYellow;
    public override string Name => "RedYellowFlash";
    public override Colour AlternateColour => Colour.BrightRed;
    public override string Sequence => @"********";
}

using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class YellowFlashAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Yellow;
    public override string Name => "YellowFlash";
    public override Colour AlternateColour => Colour.BrightYellow;
    public override string Sequence => @"********";
}

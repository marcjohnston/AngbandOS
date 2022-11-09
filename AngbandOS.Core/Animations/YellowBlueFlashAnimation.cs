using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class YellowBlueFlashAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "YellowBlueFlash";
    public override Colour AlternateColour => Colour.BrightYellow;
    public override string Sequence => @"********";
}

using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class RedWhiteFlashAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "RedWhiteFlash";
    public override Colour AlternateColour => Colour.BrightRed;
    public override string Sequence => @"********";
}

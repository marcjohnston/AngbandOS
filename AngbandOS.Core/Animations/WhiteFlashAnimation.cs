using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class WhiteFlashAnimation : Animation
{
    public override char Character => '*';
    public override string Name => "WhiteFlash";
    public override Colour AlternateColour => Colour.BrightWhite;
    public override string Sequence => @"********";
    public override Colour Colour => Colour.White;
}
using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class GreenPurpleFlashAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightPurple;
    public override string Name => "GreenPurpleFlash";
    public override Colour AlternateColour => Colour.BrightGreen;
    public override string Sequence => @"********";
}

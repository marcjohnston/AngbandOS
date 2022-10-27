using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BlueFlashAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Blue;
    public override string Name => "BlueFlash";
    public override Colour AlternateColour => Colour.BrightBlue;
    public override string Sequence => @"********";
}

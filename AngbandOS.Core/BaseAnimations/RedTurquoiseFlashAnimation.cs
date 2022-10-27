using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class RedTurquoiseFlashAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightTurquoise;
    public override string Name => "RedTurquoiseFlash";
    public override Colour AlternateColour => Colour.BrightRed;
    public override string Sequence => @"********";
}

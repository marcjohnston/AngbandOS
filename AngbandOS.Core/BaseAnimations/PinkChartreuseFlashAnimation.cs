using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class PinkChartreuseFlashAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightChartreuse;
    public override string Name => "PinkChartreuseFlash";
    public override Colour AlternateColour => Colour.BrightPink;
    public override string Sequence => @"********";
}

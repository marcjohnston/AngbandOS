using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class ChartreuseFlashAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Chartreuse;
    public override string Name => "ChartreuseFlash";
    public override Colour AlternateColour => Colour.BrightChartreuse;
    public override string Sequence => @"********";
}

using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class TurquoiseExpandAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Turquoise;
    public override string Name => "TurquoiseExpand";
    public override Colour AlternateColour => Colour.Turquoise;
    public override string Sequence => @"·oO";
}

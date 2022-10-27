using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BeigeExpandAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Beige;
    public override string Name => "BeigeExpand";
    public override Colour AlternateColour => Colour.Beige;
    public override string Sequence => @"·oO";
}

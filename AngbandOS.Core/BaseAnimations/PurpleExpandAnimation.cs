using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class PurpleExpandAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Purple;
    public override string Name => "PurpleExpand";
    public override Colour AlternateColour => Colour.Purple;
    public override string Sequence => @"·oO";
}

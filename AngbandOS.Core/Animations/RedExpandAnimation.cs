using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class RedExpandAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Red;
    public override string Name => "RedExpand";
    public override Colour AlternateColour => Colour.Red;
    public override string Sequence => @"·oO";
}

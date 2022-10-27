using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightBeigeCloudAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightBeige;
    public override string Name => "BrightBeigeCloud";
    public override Colour AlternateColour => Colour.BrightBeige;
    public override string Sequence => @"+*+*+*+";
}

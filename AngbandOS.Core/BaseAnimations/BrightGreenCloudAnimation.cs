using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightGreenCloudAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightGreen;
    public override string Name => "BrightGreenCloud";
    public override Colour AlternateColour => Colour.BrightGreen;
    public override string Sequence => @"+*+*+*+";
}

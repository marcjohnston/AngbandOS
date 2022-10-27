using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightBlueCloudAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightBlue;
    public override string Name => "BrightBlueCloud";
    public override Colour AlternateColour => Colour.BrightBlue;
    public override string Sequence => @"+*+*+*+";
}

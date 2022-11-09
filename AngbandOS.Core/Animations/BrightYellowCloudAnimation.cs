using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightYellowCloudAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightYellow;
    public override string Name => "BrightYellowCloud";
    public override Colour AlternateColour => Colour.BrightYellow;
    public override string Sequence => @"+*+*+*+";
}

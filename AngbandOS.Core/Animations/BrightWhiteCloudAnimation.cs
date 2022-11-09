using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightWhiteCloudAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "BrightWhiteCloud";
    public override Colour AlternateColour => Colour.BrightWhite;
    public override string Sequence => @"+*+*+*+";
}

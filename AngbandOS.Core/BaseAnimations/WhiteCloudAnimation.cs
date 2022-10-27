using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class WhiteCloudAnimation : BaseAnimation
{
    public override char Character => '*';
    public override string Name => "WhiteCloud";
    public override string Sequence => @"+*+*+*+";
    public override Colour Colour => Colour.White;
    public override Colour AlternateColour => Colour.White;
}

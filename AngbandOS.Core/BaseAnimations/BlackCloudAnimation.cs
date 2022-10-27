using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BlackCloudAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Black;
    public override string Name => "BlackCloud";
    public override Colour AlternateColour => Colour.Black;
    public override string Sequence => @"+*+*+*+";
}

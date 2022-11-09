using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class OrangeCloudAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Orange;
    public override string Name => "OrangeCloud";
    public override Colour AlternateColour => Colour.Orange;
    public override string Sequence => @"+*+*+*+";
}

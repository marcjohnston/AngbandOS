using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class DiamondCloudAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Diamond;
    public override string Name => "DiamondCloud";
    public override Colour AlternateColour => Colour.Diamond;
    public override string Sequence => @"+*+*+*+";
}

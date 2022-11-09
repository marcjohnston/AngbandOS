using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class SilverCloudAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Silver;
    public override string Name => "SilverCloud";
    public override Colour AlternateColour => Colour.Silver;
    public override string Sequence => @"+*+*+*+";
}

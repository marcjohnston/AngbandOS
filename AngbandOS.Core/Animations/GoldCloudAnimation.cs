using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class GoldCloudAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Gold;
    public override string Name => "GoldCloud";
    public override Colour AlternateColour => Colour.Gold;
    public override string Sequence => @"+*+*+*+";
}

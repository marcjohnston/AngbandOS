using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class CopperCloudAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Copper;
    public override string Name => "CopperCloud";
    public override Colour AlternateColour => Colour.Copper;
    public override string Sequence => @"+*+*+*+";
}

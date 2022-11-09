using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class RedCloudAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Red;
    public override string Name => "RedCloud";
    public override Colour AlternateColour => Colour.Red;
    public override string Sequence => @"+*+*+*+";
}

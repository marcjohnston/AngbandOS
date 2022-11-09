using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class ChartreuseCloudAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Chartreuse;
    public override string Name => "ChartreuseCloud";
    public override Colour AlternateColour => Colour.Chartreuse;
    public override string Sequence => @"+*+*+*+";
}

using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class TurquoiseCloudAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Turquoise;
    public override string Name => "TurquoiseCloud";
    public override Colour AlternateColour => Colour.Turquoise;
    public override string Sequence => @"+*+*+*+";
}
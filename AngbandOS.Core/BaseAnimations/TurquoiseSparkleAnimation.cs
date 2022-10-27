using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class TurquoiseSparkleAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Turquoise;
    public override string Name => "TurquoiseSparkle";
    public override Colour AlternateColour => Colour.Turquoise;
    public override string Sequence => @"·+·x·+·";
}

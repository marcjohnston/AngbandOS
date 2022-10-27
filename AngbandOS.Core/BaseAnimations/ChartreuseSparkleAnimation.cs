using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class ChartreuseSparkleAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Chartreuse;
    public override string Name => "ChartreuseSparkle";
    public override Colour AlternateColour => Colour.Chartreuse;
    public override string Sequence => @"·+·x·+·";
}

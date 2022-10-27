using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class RedSparkleAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Red;
    public override string Name => "RedSparkle";
    public override Colour AlternateColour => Colour.Red;
    public override string Sequence => @"·+·x·+·";
}

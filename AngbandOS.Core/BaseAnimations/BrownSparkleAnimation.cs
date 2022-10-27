using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrownSparkleAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Brown;
    public override string Name => "BrownSparkle";
    public override Colour AlternateColour => Colour.Brown;
    public override string Sequence => @"·+·x·+·";
}

using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrownControlAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Brown;
    public override string Name => "BrownControl";
    public override Colour AlternateColour => Colour.BrightBrown;
    public override string Sequence => @"!!!!";
}

using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrightPurpleCloudAnimation : BaseAnimation
{
    public override char Character => '*';
    public override Colour Colour => Colour.BrightPurple;
    public override string Name => "BrightPurpleCloud";
    public override Colour AlternateColour => Colour.BrightPurple;
    public override string Sequence => @"+*+*+*+";
}

using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BlueCloudAnimation : Animation
{
    public override char Character => '*';
    public override Colour Colour => Colour.Blue;
    public override string Name => "BlueCloud";
    public override Colour AlternateColour => Colour.Blue;
    public override string Sequence => @"+*+*+*+";
}
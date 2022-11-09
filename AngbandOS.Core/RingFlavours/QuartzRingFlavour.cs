using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class QuartzRingFlavour : RingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.BrightWhite;
    public override string Name => "Quartz";
}

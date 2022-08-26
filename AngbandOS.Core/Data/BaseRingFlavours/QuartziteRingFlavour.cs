using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class QuartziteRingFlavour : BaseRingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.Grey;
    public override string Name => "Quartzite";
}

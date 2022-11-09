using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class MalachiteRingFlavour : RingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.BrightGreen;
    public override string Name => "Malachite";
}

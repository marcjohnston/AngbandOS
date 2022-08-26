using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class MalachiteRingFlavour : BaseRingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.BrightGreen;
    public override string Name => "Malachite";
}

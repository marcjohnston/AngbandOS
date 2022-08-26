using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class TigerEyeRingFlavour : BaseRingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.Orange;
    public override string Name => "Tiger Eye";
}

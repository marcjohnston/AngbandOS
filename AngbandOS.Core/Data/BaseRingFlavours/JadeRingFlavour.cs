using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class JadeRingFlavour : BaseRingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.Green;
    public override string Name => "Jade";
}

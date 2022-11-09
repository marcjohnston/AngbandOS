using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class AzuriteRingFlavour : RingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.Blue;
    public override string Name => "Azurite";
}

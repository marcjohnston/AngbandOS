using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class AzuriteRingFlavour : BaseRingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.Blue;
    public override string Name => "Azurite";
}

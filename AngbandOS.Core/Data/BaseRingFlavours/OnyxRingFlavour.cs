using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class OnyxRingFlavour : BaseRingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.Red;
    public override string Name => "Onyx";
}

using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class ScarabRingFlavour : BaseRingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.Green;
    public override string Name => "Scarab";
}

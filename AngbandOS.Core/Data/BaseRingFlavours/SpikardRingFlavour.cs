using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class SpikardRingFlavour : BaseRingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.Pink;
    public override string Name => "Spikard";
}

using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class WoodenRingFlavour : RingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.Brown;
    public override string Name => "Wooden";
}

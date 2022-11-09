using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class BrassRingFlavour : RingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.Copper;
    public override string Name => "Brass";
}

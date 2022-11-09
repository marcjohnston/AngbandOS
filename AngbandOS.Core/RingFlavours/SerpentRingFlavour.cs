using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class SerpentRingFlavour : RingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.Purple;
    public override string Name => "Serpent";
}

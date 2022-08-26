using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class SerpentRingFlavour : BaseRingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.Purple;
    public override string Name => "Serpent";
}

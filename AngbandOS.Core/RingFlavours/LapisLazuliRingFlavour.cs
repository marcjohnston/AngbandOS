using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class LapisLazuliRingFlavour : RingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.Turquoise;
    public override string Name => "Lapis Lazuli";
}

using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class LapisLazuliRingFlavour : BaseRingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.Turquoise;
    public override string Name => "Lapis Lazuli";
}

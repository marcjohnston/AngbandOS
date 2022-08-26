using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class FlouriteRingFlavour : BaseRingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.Green;
    public override string Name => "Flourite";
}

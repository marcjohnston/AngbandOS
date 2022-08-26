using Cthangband.Enumerations;

namespace AngbandOS.Core;

[Serializable]
internal class AlexandriteRingFlavour : BaseRingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.BrightGreen;
    public override string Name => "Alexandrite";
}

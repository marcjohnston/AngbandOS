using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class CarnelianRingFlavour : RingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.BrightOrange;
    public override string Name => "Carnelian";
}
using AngbandOS.Core.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class LeadPlatedRodFlavour : RodFlavour
{
    public override char Character => '-';
    public override Colour Colour => Colour.Black;
    public override string Name => "Lead-Plated";
}
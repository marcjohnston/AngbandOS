using AngbandOS.Interface;

namespace AngbandOS.Core;

[Serializable]
internal class EngagementRingFlavour : BaseRingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.Gold;
    public override string Name => "Engagement";
}

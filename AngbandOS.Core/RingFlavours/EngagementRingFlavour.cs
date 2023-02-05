namespace AngbandOS.Core.RingFlavours;

[Serializable]
internal class EngagementRingFlavour : RingFlavour
{
    public override char Character => '=';
    public override Colour Colour => Colour.Gold;
    public override string Name => "Engagement";
}

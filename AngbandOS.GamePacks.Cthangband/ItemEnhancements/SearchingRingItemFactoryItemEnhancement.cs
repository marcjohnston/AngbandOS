namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SearchingRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool HideType => true;
    public override bool Search => true;
    public override int Weight => 2;
    public override int Cost => 250;
}

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SearchingAmuletItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool HideType => true;
    public override bool Search => true;
    public override int Weight => 3;
}
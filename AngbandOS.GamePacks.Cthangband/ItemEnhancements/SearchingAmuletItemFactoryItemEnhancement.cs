namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SearchingAmuletItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool HideType => true;
    public override int Weight => 3;
    public override int Cost => 600;
    public override ColorEnum Color => ColorEnum.Orange;
}

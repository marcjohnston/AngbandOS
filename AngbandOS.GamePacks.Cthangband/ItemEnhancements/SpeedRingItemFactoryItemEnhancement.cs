namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SpeedRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 25;
    public override bool HideType => true;
    public override int Weight => 2;
    public override int Value => 100000;
    public override ColorEnum Color => ColorEnum.Gold;
}

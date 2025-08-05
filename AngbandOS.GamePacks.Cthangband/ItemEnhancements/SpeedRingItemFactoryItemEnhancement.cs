namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SpeedRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 25;
    public override bool HideType => true;
    public override bool Speed => true;
    public override int Weight => 2;
}
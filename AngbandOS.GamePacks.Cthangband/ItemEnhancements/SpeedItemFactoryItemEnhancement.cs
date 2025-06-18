namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SpeedItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 25;
    public override bool HideType => true;
    public override bool Speed => true;
}
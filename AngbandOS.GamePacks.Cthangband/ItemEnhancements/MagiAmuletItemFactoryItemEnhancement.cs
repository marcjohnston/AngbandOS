namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class MagiAmuletItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 25;
    public override bool FreeAct => true;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool SeeInvis => true;
    public override int Weight => 3;
    public override int Cost => 30000;
    public override ColorEnum Color => ColorEnum.Orange;
}

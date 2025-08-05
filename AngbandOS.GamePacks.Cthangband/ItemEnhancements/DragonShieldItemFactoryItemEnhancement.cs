namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DragonShieldItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 5;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool CanReflectBoltsAndArrows => true;
    public override int Weight => 100;
}

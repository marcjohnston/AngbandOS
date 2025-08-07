namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DragonHelmItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int TreasureRating => 5;
    public override bool IgnoreAcid => true;
    public override bool IgnoreCold => true;
    public override bool IgnoreElec => true;
    public override bool IgnoreFire => true;
    public override bool CanReflectBoltsAndArrows => true;
    public override int Weight => 50;
    public override int Cost => 10000;
}

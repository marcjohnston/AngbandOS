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
    public override int Cost => 10000;
    public override int DamageDice => 1;
    public override int DiceSides => 3;
    public override ColorEnum Color => ColorEnum.BrightGreen;
}

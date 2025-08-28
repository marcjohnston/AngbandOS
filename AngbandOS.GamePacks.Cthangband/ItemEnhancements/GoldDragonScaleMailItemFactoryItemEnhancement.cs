namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GoldDragonScaleMailItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? ActivationName => nameof(ActivationsEnum.BallOfSound130r2Every1d450p450DirectionalActivation);
    public override bool? IgnoreAcid => true;
    public override bool? IgnoreCold => true;
    public override bool? IgnoreElec => true;
    public override bool? IgnoreFire => true;
    public override bool? ResSound => true;
    public override int? TreasureRating => 30;
    public override int? Weight => 200;
    public override int? Value => 35000;
    public override int? DamageDice => 2;
    public override int? DiceSides => 4;
    public override ColorEnum? Color => ColorEnum.Gold;
}

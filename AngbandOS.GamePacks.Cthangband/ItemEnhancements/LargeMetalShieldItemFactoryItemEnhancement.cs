namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LargeMetalShieldItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? CanReflectBoltsAndArrows => true;
    public override int? Weight => 120;
    public override int? Value => 200;
    public override int? DamageDice => 1;
    public override int? DiceSides => 3;
    public override ColorEnum? Color => ColorEnum.Grey;
    public override string? BaseArmorClass => "5";
}

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class IronCrownArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? IgnoreAcid => true;
    public override int? Weight => 20;
    public override int? Value => 500;
    public override int? DamageDice => 1;
    public override int? DiceSides => 1;
    public override ColorEnum? Color => ColorEnum.Grey;
    public override string? HatesAcid => "true";
}

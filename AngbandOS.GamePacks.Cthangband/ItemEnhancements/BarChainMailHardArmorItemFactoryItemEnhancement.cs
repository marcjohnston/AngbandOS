namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BarChainMailHardArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? CanReflectBoltsAndArrows => true;
    public override int? Weight => 280;
    public override int? Value => 950;
    public override int? DamageDice => 1;
    public override int? DiceSides => 4;
    public override ColorEnum? Color => ColorEnum.Grey;
    public override string? BaseArmorClass => "18";
}

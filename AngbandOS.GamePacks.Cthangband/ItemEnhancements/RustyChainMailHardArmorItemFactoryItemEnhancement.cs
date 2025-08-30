namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RustyChainMailHardArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? CanReflectBoltsAndArrows => true;
    public override int? Weight => 200;
    public override int? Value => 550;
    public override int? DamageDice => 1;
    public override int? DiceSides => 4;
    public override ColorEnum? Color => ColorEnum.Red;
    public override string? BaseArmorClass => "14";
    public override string? HatesAcid => "true";
}

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AugmentedChainMailHardArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Reflect => true;
    public override int? Weight => 270;
    public override int? Value => 900;
    public override int? DamageDice => 1;
    public override int? DiceSides => 4;
    public override ColorEnum? Color => ColorEnum.Grey;
    public override string? BaseArmorClass => "16";
    public override string? HatesAcid => "true";
    public override string? Hits => "-2";
}

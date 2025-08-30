namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RobeSoftArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? Weight => 20;
    public override int? Value => 4;
    public override ColorEnum? Color => ColorEnum.Blue;
    public override string? BaseArmorClass => "2";
    public override string? HatesAcid => "true";
    public override string? HatesFire => "true";
}

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class LeatherGlovesItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? Weight => 5;
    public override int? Value => 3;
    public override ColorEnum? Color => ColorEnum.BrightBrown;
    public override string? BaseArmorClass => "1";
    public override string? HatesAcid => "true";
    public override string? HatesFire => "true";
}

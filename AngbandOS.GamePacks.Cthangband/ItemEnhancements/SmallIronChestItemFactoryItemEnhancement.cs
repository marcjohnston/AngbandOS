namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SmallIronChestItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? Weight => 300;
    public override int? Value => 100;
    public override int? DamageDice => 2;
    public override int? DiceSides => 4;
    public override ColorEnum? Color => ColorEnum.Grey;
    public override string? HatesAcid => "true";
    public override string? HatesFire => "true";
}

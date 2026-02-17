namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ClothCloakItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Reflect => true;
    public override int? Weight => 10;
    public override int? Value => 3;
    public override ColorEnum? Color => ColorEnum.Green;
    public override string? BaseArmorClass => "1";
    public override string? HatesAcid => "true";
    public override string? HatesFire => "true";
}

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ClothCloakItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? CanReflectBoltsAndArrows => true;
    public override int? Weight => 10;
    public override int? Value => 3;
    public override ColorEnum? Color => ColorEnum.Green;
    public override string? BaseArmorClass => "1";
}

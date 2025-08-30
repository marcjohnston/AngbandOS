namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class RuinedChestItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? Weight => 250;
    public override ColorEnum? Color => ColorEnum.Grey;
    public override string? HatesAcid => "true";
    public override string? HatesFire => "true";
}

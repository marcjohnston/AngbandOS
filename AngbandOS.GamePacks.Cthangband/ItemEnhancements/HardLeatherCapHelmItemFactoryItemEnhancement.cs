namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class HardLeatherCapHelmItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Reflect => true;
    public override int? Weight => 15;
    public override int? Value => 12;
    public override ColorEnum? Color => ColorEnum.Brown;
    public override string? BaseArmorClass => "2";
    public override string? HatesAcid => "true";
}

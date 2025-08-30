namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class FilthyRagSoftArmorItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? Weight => 20;
    public override int? Value => 1;
    public override ColorEnum? Color => ColorEnum.Black;
    public override string? BaseArmorClass => "1";
}

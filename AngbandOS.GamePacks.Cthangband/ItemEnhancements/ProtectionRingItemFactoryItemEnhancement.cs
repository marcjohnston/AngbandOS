namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ProtectionRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? Weight => 2;
    public override int? Value => 500;
    public override string? HatesElectricity => "true";
}

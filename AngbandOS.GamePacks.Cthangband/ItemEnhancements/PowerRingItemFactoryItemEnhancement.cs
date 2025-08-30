namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PowerRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? Weight => 2;
    public override int? Value => 5000000;
    public override string? HatesElectricity => "true";
}

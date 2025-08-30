namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class BarahirRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? Weight => 2;
    public override int? Value => 65000;
    public override string? HatesElectricity => "true";
}

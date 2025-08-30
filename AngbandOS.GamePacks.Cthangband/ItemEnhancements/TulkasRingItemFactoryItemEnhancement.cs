namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class TulkasRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? Weight => 2;
    public override int? Value => 150000;
    public override string? HatesElectricity => "true";
}

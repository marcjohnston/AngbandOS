namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class NaryaRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? Weight => 2;
    public override int? Value => 100000;
    public override string? HatesElectricity => "true";
}

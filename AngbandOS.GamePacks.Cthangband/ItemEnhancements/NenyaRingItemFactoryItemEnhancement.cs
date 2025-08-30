namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class NenyaRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override int? Weight => 2;
    public override int? Value => 200000;
    public override string? HatesElectricity => "true";
}

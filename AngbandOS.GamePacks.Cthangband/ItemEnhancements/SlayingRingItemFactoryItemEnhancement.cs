namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SlayingRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? ShowMods => true;
    public override int? Weight => 2;
    public override int? Value => 1000;
    public override string? HatesElectricity => "true";
}

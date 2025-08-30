namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SearchingRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? HideType => true;
    public override int? Weight => 2;
    public override int? Value => 250;
    public override string? HatesElectricity => "true";
}

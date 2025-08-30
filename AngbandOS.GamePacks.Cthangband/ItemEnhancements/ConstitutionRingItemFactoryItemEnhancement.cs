namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ConstitutionRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? HideType => true;
    public override int? Weight => 2;
    public override int? Value => 500;
    public override string? HatesElectricity => "true";
}

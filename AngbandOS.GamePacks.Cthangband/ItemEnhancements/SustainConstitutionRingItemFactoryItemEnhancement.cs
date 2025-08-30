namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SustainConstitutionRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override bool? SustCon => true;
    public override int? Weight => 2;
    public override int? Value => 750;
    public override string? HatesElectricity => "true";
}

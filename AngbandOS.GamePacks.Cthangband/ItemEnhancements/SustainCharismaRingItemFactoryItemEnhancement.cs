namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SustainCharismaRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override bool? SustCha => true;
    public override int? Weight => 2;
    public override int? Value => 500;
    public override string? HatesElectricity => "true";
}

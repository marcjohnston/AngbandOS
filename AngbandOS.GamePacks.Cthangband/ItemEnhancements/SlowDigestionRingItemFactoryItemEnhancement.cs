namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class SlowDigestionRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override bool? SlowDigest => true;
    public override int? Weight => 2;
    public override int? Value => 250;
    public override string? HatesElectricity => "true";
}

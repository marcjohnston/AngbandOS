namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class AggravateMonsterRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? Aggravate => true;
    public override bool? IsCursed => true;
    public override bool? EasyKnow => true;
    public override int? Weight => 2;
    public override int? Value => -15000;
    public override string? HatesElectricity => "true";
    public override bool? Valueless => true;
}

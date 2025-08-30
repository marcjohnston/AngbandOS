namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class DisenchantmentResistanceRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool? EasyKnow => true;
    public override bool? ResDisen => true;
    public override int? Weight => 2;
    public override int? Value => 15000;
    public override string? HatesElectricity => "true";
}

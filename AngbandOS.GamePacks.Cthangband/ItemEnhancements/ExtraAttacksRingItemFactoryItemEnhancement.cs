namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ExtraAttacksRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? Attacks => "1";
    public override int? Weight => 2;
    public override int? Value => 100000;
    public override string? HatesElectricity => "true";
}

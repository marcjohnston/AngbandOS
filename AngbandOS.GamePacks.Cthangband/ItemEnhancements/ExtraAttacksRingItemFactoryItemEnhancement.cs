namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ExtraAttacksRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? BonusAttacksRollExpression => "1";
    public override int? Weight => 2;
    public override int? Value => 100000;
}

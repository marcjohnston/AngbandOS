namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ExtraAttacksRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string? BonusAttacksRollExpression => "1";
    public override int Weight => 2;
    public override int Cost => 100000;
}

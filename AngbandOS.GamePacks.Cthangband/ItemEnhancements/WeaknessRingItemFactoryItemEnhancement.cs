namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaknessRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool IsCursed => true;
    public override bool HideType => true;
    public override string? BonusStrengthRollExpression => "-5";
    public override int Weight => 2;
}
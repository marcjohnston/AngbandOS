namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaknessRingItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool IsCursed => true;
    public override bool HideType => true;
    public override string? BonusStrengthRollExpression => "-5";
    public override int Weight => 2;
    public override ColorEnum Color => ColorEnum.Gold;
    public override int Value => -11000;
}

namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class WeaknessItemFactoryItemEnhancement : ItemEnhancementGameConfiguration
{
    public override bool IsCursed => true;
    public override bool HideType => true;
    public override string? BonusStrengthRollExpression => "-5";
    public override bool Str => true;
}
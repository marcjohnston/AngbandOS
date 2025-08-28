namespace AngbandOS.GamePacks.Cthangband;
    [Serializable]
public class SpriteRaceItemEnhancement : ItemEnhancementGameConfiguration
{
    public override string BonusStrengthRollExpression => "-4";
    public override string BonusCharismaRollExpression => "2";
    public override string BonusConstitutionRollExpression => "-2";
    public override string BonusWisdomRollExpression => "3";
    public override string BonusIntelligenceRollExpression => "3";
    public override string BonusDexterityRollExpression => "3";
    public override int? Value => 4500;
}

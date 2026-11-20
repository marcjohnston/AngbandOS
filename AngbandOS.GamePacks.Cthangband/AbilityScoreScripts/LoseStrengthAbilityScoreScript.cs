namespace AngbandOS.GamePacks.Cthangband;

public class LoseStrengthAbilityScoreScript : AbilityScoreScriptGameConfiguration
{
    public override AbilitiesEnum AbilityEnumValue => AbilitiesEnum.StrengthAbility;
    public override bool TrueToIncreaseFalseToDecrease => false;
}

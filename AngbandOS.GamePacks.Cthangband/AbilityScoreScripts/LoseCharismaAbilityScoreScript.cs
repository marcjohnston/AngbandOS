namespace AngbandOS.GamePacks.Cthangband;

public class LoseCharismaAbilityScoreScript : AbilityScoreScriptGameConfiguration
{
    public override AbilitiesEnum AbilityEnumValue => AbilitiesEnum.CharismaAbility;
    public override bool TrueToIncreaseFalseToDecrease => false;
}

namespace AngbandOS.GamePacks.Cthangband;

public class LoseWisdomAbilityScoreScript : AbilityScoreScriptGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);
    public override bool TrueToIncreaseFalseToDecrease => false;
}

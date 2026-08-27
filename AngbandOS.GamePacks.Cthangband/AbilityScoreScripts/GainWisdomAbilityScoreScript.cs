namespace AngbandOS.GamePacks.Cthangband;

public class GainWisdomAbilityScoreScript : AbilityScoreScriptGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);
    public override bool TrueToIncreaseFalseToDecrease => true;
}

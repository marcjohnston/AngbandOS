namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class GainWisdomAbilityScoreScript : AbilityScoreScriptGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);
    public override bool TrueToIncreaseFalseToDecrease => true;
}

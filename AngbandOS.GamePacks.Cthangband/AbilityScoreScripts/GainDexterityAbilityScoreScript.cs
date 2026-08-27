namespace AngbandOS.GamePacks.Cthangband;
public class GainDexterityAbilityScoreScript : AbilityScoreScriptGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.DexterityAbility);
    public override bool TrueToIncreaseFalseToDecrease => true;
}
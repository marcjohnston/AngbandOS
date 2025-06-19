namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CultistCharacterClassCharismaAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.CharismaAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.CultistCharacterClass);
    public override int Bonus => -2;
}
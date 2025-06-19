namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CultistCharacterClassConstitutionAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.ConstitutionAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.CultistCharacterClass);
    public override int Bonus => -2;
}
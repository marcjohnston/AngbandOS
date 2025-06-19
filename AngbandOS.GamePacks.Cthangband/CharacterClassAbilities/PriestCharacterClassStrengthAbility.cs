namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PriestCharacterClassStrengthAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.StrengthAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.PriestCharacterClass);
    public override int Bonus => -1;
}
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class ChosenOneCharacterClassStrengthAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.StrengthAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.ChosenOneCharacterClass);
    public override int Bonus => 3;
}
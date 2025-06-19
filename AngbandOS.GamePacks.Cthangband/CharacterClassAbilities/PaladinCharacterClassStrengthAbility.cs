namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PaladinCharacterClassStrengthAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.StrengthAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.PaladinCharacterClass);
    public override int Bonus => 3;
}
namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class PaladinCharacterClassCharismaAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.CharismaAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.PaladinCharacterClass);
    public override int Bonus => 2;
}
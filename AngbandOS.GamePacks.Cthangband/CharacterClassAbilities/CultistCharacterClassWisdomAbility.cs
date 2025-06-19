namespace AngbandOS.GamePacks.Cthangband;

[Serializable]
public class CultistCharacterClassWisdomAbility : CharacterClassAbilityGameConfiguration
{
    public override string AbilityBindingKey => nameof(AbilitiesEnum.WisdomAbility);
    public override string CharacterClassBindingKey => nameof(CharacterClassesEnum.CultistCharacterClass);
    public override int Bonus => 0;
}
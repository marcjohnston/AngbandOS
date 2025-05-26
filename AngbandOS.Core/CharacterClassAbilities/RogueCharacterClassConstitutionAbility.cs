namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class RogueCharacterClassConstitutionAbility : CharacterClassAbility
{
    private RogueCharacterClassConstitutionAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(ConstitutionAbility);
    public override string CharacterClassBindingKey => nameof(RogueCharacterClass);
    public override int Bonus => 1;
}
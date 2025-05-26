namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class RogueCharacterClassCharismaAbility : CharacterClassAbility
{
    private RogueCharacterClassCharismaAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(CharismaAbility);
    public override string CharacterClassBindingKey => nameof(RogueCharacterClass);
    public override int Bonus => -1;
}
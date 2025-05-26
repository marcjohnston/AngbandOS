namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class MonkCharacterClassWisdomAbility : CharacterClassAbility
{
    private MonkCharacterClassWisdomAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(WisdomAbility);
    public override string CharacterClassBindingKey => nameof(MonkCharacterClass);
    public override int Bonus => 1;
}
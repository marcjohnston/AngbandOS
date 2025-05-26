namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class RangerCharacterClassWisdomAbility : CharacterClassAbility
{
    private RangerCharacterClassWisdomAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(WisdomAbility);
    public override string CharacterClassBindingKey => nameof(RangerCharacterClass);
    public override int Bonus => 0;
}
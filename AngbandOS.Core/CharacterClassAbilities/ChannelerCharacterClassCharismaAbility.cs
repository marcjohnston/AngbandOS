namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class ChannelerCharacterClassCharismaAbility : CharacterClassAbility
{
    private ChannelerCharacterClassCharismaAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(CharismaAbility);
    public override string CharacterClassBindingKey => nameof(ChannelerCharacterClass);
    public override int Bonus => 3;
}
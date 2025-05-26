namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class MysticCharacterClassCharismaAbility : CharacterClassAbility
{
    private MysticCharacterClassCharismaAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(CharismaAbility);
    public override string CharacterClassBindingKey => nameof(MysticCharacterClass);
    public override int Bonus => 0;
}
namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class MysticCharacterClassStrengthAbility : CharacterClassAbility
{
    private MysticCharacterClassStrengthAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(StrengthAbility);
    public override string CharacterClassBindingKey => nameof(MysticCharacterClass);
    public override int Bonus => 2;
}
namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class MysticCharacterClassIntelligenceAbility : CharacterClassAbility
{
    private MysticCharacterClassIntelligenceAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    public override string CharacterClassBindingKey => nameof(MysticCharacterClass);
    public override int Bonus => -1;
}
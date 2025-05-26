namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class CultistCharacterClassIntelligenceAbility : CharacterClassAbility
{
    private CultistCharacterClassIntelligenceAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    public override string CharacterClassBindingKey => nameof(CultistCharacterClass);
    public override int Bonus => 4;
}
namespace AngbandOS.Core.CharacterClassAbilities;

[Serializable]
internal class WarriorCharacterClassIntelligenceAbility : CharacterClassAbility
{
    private WarriorCharacterClassIntelligenceAbility(Game game) : base(game) { }
    public override string AbilityBindingKey => nameof(IntelligenceAbility);
    public override string CharacterClassBindingKey => nameof(WarriorCharacterClass);
    public override int Bonus => -2;
}